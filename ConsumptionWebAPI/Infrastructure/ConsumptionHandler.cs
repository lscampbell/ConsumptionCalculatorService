using System.Net.WebSockets;
using System.Threading.Tasks;
using ConsumptionWebAPI.Infrastructure.WebSocketManager;
using ConsumptionWebAPI.Infrastructure.WebSocketManager.Common;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumptionWebAPI.Infrastructure
{
    public class ConsumptionHandler: WebSocketHandler
    {
        public ConsumptionHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }
        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            var socketId = WebSocketConnectionManager.GetId(socket);

            var message = new WebSocketManager.Common.Message()
            {
                MessageType = MessageType.Text,
                Data = $"{socketId} is now connected"
            };

            await SendMessageToAllAsync(message);
        }

        public void SendMessage(string socketId, string message)
        {
            const string kafkaEndpoint = "127.0.0.1:9092";

            // The Kafka topic i'll be using
            const string kafkaTopic = "consumptionTransformed";

            // Create the consumer configuration
            var consumerConfig = new Dictionary<string, object>
            {
                { "group.id", "energyBuyer"},
                { "bootstrap.servers", kafkaEndpoint }
            };

            // Create the consumer
            using (var consumer = new Consumer<string, string>(consumerConfig, new StringDeserializer(Encoding.UTF8), new StringDeserializer(Encoding.UTF8)))
            {
                // Subscribe to the OnMessage event
                consumer.OnMessage += async (obj, msg) =>
                {
                    Console.WriteLine($"Received: {msg.Value}");
                    await InvokeClientMethodToAllAsync("receiveMessage", socketId, msg.Value);
                };

                // Subscribe to the Kafka topic
                consumer.Subscribe(new List<string> { kafkaTopic });

                try
                {
                    // Poll for messages
                    while (true)
                    {
                        consumer.Poll(-1);
                    }
                }
                catch (System.Exception e)
                {
                    Console.Write(e.StackTrace);
                    throw;
                }
                finally
                {
                    consumer.Dispose();
                }
            }
        }

        public override async Task OnDisconnected(WebSocket socket)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);

            await base.OnDisconnected(socket);

            var message = new WebSocketManager.Common.Message()
            {
                MessageType = MessageType.Text,
                Data = $"{socketId} disconnected"
            };
            await SendMessageToAllAsync(message);
        }
    }
}