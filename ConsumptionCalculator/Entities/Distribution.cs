namespace EnergyBuyer.ConsumptionCalculator.Entities
{
    public class Distribution
    {
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MarketParticipantId { get; set; }
        public string LLF { get; set; }
        public float Factor { get; set; }
    }
}