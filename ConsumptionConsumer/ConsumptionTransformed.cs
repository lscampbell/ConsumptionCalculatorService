using System;

namespace EnergyBuyer.ConsumptionConsumer
{
    public class ConsumptionTransformed
    {
        public Guid Id { get; set; }
        public string Mpan { get; set; }
        public string SupplyPointRef { get; set; }
        public string Date { get; set; }
        public int Kwh { get; set; }
        public float Lead { get; set; }
        public float Lag { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public byte Estimated { get; set; }
        public string MarketParticpentId { get; set; }
        public string LLF { get; set; }
        public float DLoss { get; set; }
        public float TLoss { get; set; }
        public float DLossFactor { get; set; }
        public float TLossFactor { get; set; }
    }
}