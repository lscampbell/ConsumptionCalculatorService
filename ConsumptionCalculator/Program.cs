using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;
using EnergyBuyer.ConsumptionCalculator.Entities;
using EnergyBuyer.ConsumptionCalculator.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System.IO;

namespace EnergyBuyer.ConsumptionCalculator
{
    class Program
    {
        private static IConfigurationRoot Configuration;
        static Dictionary<string, object> Config = new Dictionary<string, object>(); 

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Config = new Dictionary<string, object>
            {
                { "group.id", Configuration["GROUP_ID"] },
                { "bootstrap.servers", Configuration["KAFKA_END_POINT"] }
            };

            // Create the consumer
            using (var consumer = new Consumer<string, string>(Config, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                // Subscribe to the OnMessage event
                consumer.OnMessage += async (obj, msg) => {
                    Console.WriteLine($"Received Raw Consumption: {msg.Value}");
                    var data = JsonConvert.DeserializeObject<Consumption>(msg.Value);
                    
                    // Parser mpan to get the MarketParticantId and LLF
                    var mpan = MpanParser.Split(data.Mpan);
                    
                    if(mpan.Complete) 
                    {
                        var transformed = 
                            new Calculate(data, 
                                new GetFactors(MpanHelper.GetMarketParticipantId(mpan.Result.DistributionId), mpan.Result.LLF, data.Date, data.StartTime).Results)
                                    .Transform();

                        Publish(transformed);
                    }
                };

                consumer.OnLog += (obj, e) => { 

                };
                // Subscribe to the Kafka topic
                consumer.Subscribe(new List<string> { Configuration["CONSUMER_TOPIC"] });

                // Handle Cancel Keypress
                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // Prevent the process from terminating
                    cancelled = true;
                };

                Console.WriteLine("Ctrl-C to exit");

                // Poll for messages
                while (!cancelled)
                {
                    consumer.Poll(-1);
                }
            }
        }

        static void Publish(ConsumptionTransformed consumpitonObj)
        {
            using (var producer = new Producer<string, string>(Config, new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8)))
            {
                var newMess = JsonConvert.SerializeObject(consumpitonObj);
                var result = producer.ProduceAsync(Configuration["PRODUCER_TOPIC"], consumpitonObj.Id.ToString(), newMess).GetAwaiter().GetResult();
                Console.WriteLine($"Event Transformed Consumption sent on Partition: {result.Partition} with Offset: {result.Offset}\n" +
                    $"Data: {newMess}");
                producer.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}