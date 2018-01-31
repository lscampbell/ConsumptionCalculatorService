# ConsumptionCalculatorService
This is a Kafka Service that calculates distribution and transmission losses on raw consumption data. The main service has two helpers that sit either side of the pipeline. The producer pushes raw consumption into the service. The calculations take place and the transformed data is pushed through to the consumer.
