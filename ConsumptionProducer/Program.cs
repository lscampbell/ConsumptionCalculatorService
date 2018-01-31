using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Newtonsoft.Json;

namespace EnergyBuyer.ConsumptionProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Kafka endpoint address
            const string kafkaEndpoint = "127.0.0.1:9092";

            // The Kafka topic i'll be using
            const string kafkaTopic = "consumptionUploaded";

            // Create the producer configuration
            var producerConfig = new Dictionary<string, object> {
                { "group.id", "energyBuyer"},
                {"bootstrap.servers", kafkaEndpoint}
            };

            // Create the producer
            using (var producer = new Producer<string, string>(producerConfig, new StringSerializer(Encoding.UTF8), new StringSerializer(Encoding.UTF8)))
            {
                // Send 10 messages to the topic
                for (int i = 0; i < 10; i++)
                {
                    for(int j =0; j < 10; j++){
                        var newMess = JsonConvert.SerializeObject(ConsumptionData.Get());
                        var result = producer.ProduceAsync(kafkaTopic, ConsumptionData.Get().Id.ToString(), newMess).GetAwaiter().GetResult();
                        Console.WriteLine($"Event {i} sent on Partition: {result.Partition} with Offset: {result.Offset}\n" +
                            $"Data: {newMess}");
                        producer.Flush(TimeSpan.FromSeconds(10));
                    }
                    // Random r = new Random();
                    // Thread.Sleep(r.Next(0, 0));
                }
            }
        }        
    }
}
