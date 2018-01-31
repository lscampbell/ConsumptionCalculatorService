using System.Threading.Tasks;
using EnergyBuyer.ConsumptionCalculator.Entities;

namespace EnergyBuyer.ConsumptionCalculator
{
    public class Calculate : ICalculate
    {
        Consumption _conObj;
        Factors _disObj;
        float _dLoss;
        float _tLoss;
        
        public Calculate() {}
        public Calculate(Consumption conObj, Factors disObj)
        {
            _conObj = conObj;
            _disObj = disObj;
            Calculation();
        }
        void Calculation()
        {
            _dLoss = Calculation(_conObj.Kwh, _disObj.DistributionFactor.Factor);
            _tLoss = Calculation(_conObj.Kwh, _disObj.TransmissionFactor.Factor);
        }
        public float Calculation(float kwh, float factor) => kwh * (factor - 1.0F);

        public  ConsumptionTransformed Transform()
        {
            return new ConsumptionTransformed {
                Date = _conObj.Date, 
                DLoss = _dLoss,
                DLossFactor = _disObj.DistributionFactor.Factor,
                EndTime = _conObj.EndTime, 
                Estimated = _conObj.Estimated,
                Id = _conObj.Id,
                Kwh = _conObj.Kwh,
                Lag = _conObj.Lag,
                Lead = _conObj.Lead,
                LLF =  _disObj.DistributionFactor.LLF, 
                MarketParticipantId = _disObj.DistributionFactor.MarketParticipantId, 
                Mpan = _conObj.Mpan,
                StartTime = _conObj.StartTime, 
                SupplyPointRef = _conObj.SupplyPointRef,
                TLoss = _tLoss,
                TLossFactor = _disObj.TransmissionFactor.Factor
            };
        }
    }
}