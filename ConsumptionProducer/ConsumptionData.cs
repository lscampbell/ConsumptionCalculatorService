using System;

namespace EnergyBuyer.ConsumptionProducer
{
    public static class ConsumptionData
    {
        static Random _random = new Random();
        static DateTime _date = new DateTime(2012,1,1,0,0,0);
        public static Consumption Get()
        {
            var data = new Consumption
                {
                    Id = Guid.NewGuid(),
                    Mpan = "009998011900033146143",
                    SupplyPointRef = "1900033146143",
                    Date = _date.ToString("yyyy-MM-dd"),
                    Kwh = RandomInt(1200),
                    Lead = RandomFloat(8),
                    Lag = RandomFloat(4),
                    StartTime = _date.ToLongTimeString(),
                    EndTime = _date.AddMinutes(30).ToLongTimeString(),
                    Estimated = (byte)RandomInt(2)
                };
            _date = _date.AddMinutes(30);
            return data;
        }
        static int RandomInt(int range) => _random.Next(0, range); // for ints
        static float RandomFloat(int range) => (float)_random.NextDouble()* range; // for doubles;
    }
}