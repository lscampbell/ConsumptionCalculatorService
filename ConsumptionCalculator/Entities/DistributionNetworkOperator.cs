namespace EnergyBuyer.ConsumptionCalculator.Entities
{
    public class DistributionNetworkOperator
    {
        public int DistributionId { get; set; }
        public string DistributionName { get; set; }
        public string Operator { get; set; }
        public string MarketParticipantId { get; set; }
        public string GSPGroupId { get; set; }
    }
}