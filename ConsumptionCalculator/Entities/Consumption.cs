using System;

namespace EnergyBuyer.ConsumptionCalculator.Entities
{
    public class Consumption
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
    }
}