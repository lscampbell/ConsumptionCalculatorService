using System.Threading.Tasks;
using EnergyBuyer.ConsumptionCalculator.Entities;

namespace EnergyBuyer.ConsumptionCalculator
{
    public interface ICalculate
    {
        ConsumptionTransformed Transform();
        float Calculation(float kwh, float factor);
    }
}