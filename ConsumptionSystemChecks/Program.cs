// Copyright 2016-2017 Confluent Inc., 2015-2016 Andreas Heider
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Derived from: rdkafka-dotnet, licensed under the 2-clause BSD License.
//
// Refer to LICENSE for more information.

using System;
using System.Linq;
using System.Collections.Generic;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace EnergyBuyer.ConsumptionSystemChecks
{
    public class Program
    {
        static string ToString(int[] array) => $"[{string.Join(", ", array)}]";

        static void ListGroups(string brokerList)
        {
            const string kafkaEndpoint = "127.0.0.1:9092";
            // Create the consumer configuration
            var config = new Dictionary<string, object>
            {
                { "group.id", "energyBuyer"},
                { "bootstrap.servers", kafkaEndpoint }
            };

            using (var producer = new Producer(config))
            {
                var groups = producer.ListGroups(TimeSpan.FromSeconds(10));

                Console.WriteLine($"Consumer Groups:");
                foreach (var g in groups)
                {
                    Console.WriteLine($"  Group: {g.Group} {g.Error} {g.State}");
                    Console.WriteLine($"  Broker: {g.Broker.BrokerId} {g.Broker.Host}:{g.Broker.Port}");
                    Console.WriteLine($"  Protocol: {g.ProtocolType} {g.Protocol}");
                    Console.WriteLine($"  Members:");
                    foreach (var m in g.Members)
                    {
                        Console.WriteLine($"    {m.MemberId} {m.ClientId} {m.ClientHost}");
                        Console.WriteLine($"    Metadata: {m.MemberMetadata.Length} bytes");
                        Console.WriteLine($"    Assignment: {m.MemberAssignment.Length} bytes");
                    }
                }
            }
        }

        static void PrintMetadata(string brokerList)
        {
             const string kafkaEndpoint = "127.0.0.1:9092";
            // Create the consumer configuration
            var config = new Dictionary<string, object>
            {
                { "group.id", "energyBuyer"},
                { "bootstrap.servers", kafkaEndpoint }
            };
            
            using (var consumer = new Consumer(config))
            using (var producer = new Producer(config))
            {
                var producerMeta = producer.GetMetadata(true, null);
                Console.WriteLine($"{producerMeta.OriginatingBrokerId} {producerMeta.OriginatingBrokerName}");
                producerMeta.Brokers.ForEach(broker =>
                    Console.WriteLine($"Broker: {broker.BrokerId} {broker.Host}:{broker.Port}"));

                producerMeta.Topics.ForEach(topic =>
                {
                    Console.WriteLine($"Topic: {topic.Topic} {topic.Error}");
                    topic.Partitions.ForEach(partition =>
                    {
                        Console.WriteLine($"  Partition: {partition.PartitionId}");
                        Console.WriteLine($"    Replicas: {ToString(partition.Replicas)}");
                        Console.WriteLine($"    InSyncReplicas: {ToString(partition.InSyncReplicas)}");
                    });
                });
                
                var consumerMeta = consumer.GetMetadata(true, TimeSpan.FromSeconds(10));
                Console.WriteLine($"{consumerMeta.OriginatingBrokerId} {consumerMeta.OriginatingBrokerName}");
                consumerMeta.Brokers.ForEach(broker =>
                    Console.WriteLine($"Broker: {broker.BrokerId} {broker.Host}:{broker.Port}"));

                consumerMeta.Topics.ForEach(topic =>
                {
                    Console.WriteLine($"Topic: {topic.Topic} {topic.Error}");
                    topic.Partitions.ForEach(partition =>
                    {
                        Console.WriteLine($"  Partition: {partition.PartitionId}");
                        Console.WriteLine($"    Replicas: {ToString(partition.Replicas)}");
                        Console.WriteLine($"    InSyncReplicas: {ToString(partition.InSyncReplicas)}");
                    });
                });
                Console.WriteLine($"Current Topic: {consumer.Subscription}");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"Hello RdKafka!");
            Console.WriteLine($"{Library.Version:X}");
            Console.WriteLine($"{Library.VersionString}");
            Console.WriteLine($"{string.Join(", ", Library.DebugContexts)}");

            ListGroups("energyBuyer");
            PrintMetadata("energyBuyer");
        }
    }
}