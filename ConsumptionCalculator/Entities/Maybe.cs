namespace EnergyBuyer.ConsumptionCalculator.Entities
{
    public class Maybe<T>
    {
        public bool Complete { get; set; }
        public string Message { get; set; } 
        public T Result { get; set; }
    }
}