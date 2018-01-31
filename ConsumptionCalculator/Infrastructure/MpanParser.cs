using System;
using EnergyBuyer.ConsumptionCalculator.Entities;

namespace EnergyBuyer.ConsumptionCalculator.Infrastructure
{
    public class MpanParser
    {
        public static bool MPANIsValid(string mpan)
        {
            // Set initial conditions.
            bool validationResult = false;

            if (mpan.Length > 12) {
                //Read the check digit into an Integer variable.
                int intCheckDigit = 0;
                if (int.TryParse(mpan.Substring(mpan.Length - 1), out intCheckDigit)) {
                    string strTest = mpan.Substring(mpan.Length - 13, 12);
                    int[] intPrimes = {3, 5, 7, 13, 17, 19, 23, 29, 31, 37, 41, 43};
                    int productTotal = 0;
                    bool blnError = false;

                    for(int i = 0; i <= 11; i++) {
                        int intTestDigit = 0;
                        if (int.TryParse(strTest.Substring(i, 1), out intTestDigit)) {
                            productTotal += (intTestDigit * intPrimes[i]); 
                        } 
                        else {
                            blnError = true;
                            break; 
                        }
                    }
                    if (!blnError) {
                        validationResult = ((productTotal % 11 % 10) == intCheckDigit);
                    } 
                    else { 
                        validationResult = false; // Due to a parsing error.
                    } 
                }
            }
            return validationResult;
        } 

        public static Maybe<MeterPointAdministrationNumber> Split(string mpan)
        {
            var result = new Maybe<MeterPointAdministrationNumber> 
                            { 
                                Complete = false, 
                                Result = new MeterPointAdministrationNumber(), 
                                Message = $"Error splitting mpan: {mpan}" 
                            };
            
            if(!MPANIsValid(mpan))
                return result;

            switch(mpan.Length)
            {
                case 21:
                    {
                        result.Complete = true;
                        result.Result = new MeterPointAdministrationNumber{
                            Mpan = mpan,
                            SupplyPointRef = mpan.Substring(8, 13),
                            ProfileType = mpan.Substring(0, 2),
                            MeterTimeSwitchCode = mpan.Substring(2, 3),
                            LLF = mpan.Substring(5, 3),
                            DistributionId = Int32.Parse(mpan.Substring(8, 2)),
                            UniqueIdentifer = mpan.Substring(10, 8),
                            CheckDigit = mpan.Substring(mpan.Length - 3)
                        };

                    }
                    break;
                case 13:
                    {
                        result.Complete = true;
                        result.Result = new MeterPointAdministrationNumber{
                            Mpan = mpan,
                            SupplyPointRef = mpan,
                            CheckDigit = mpan.Substring(mpan.Length - 3),
                            DistributionId = Int32.Parse(mpan.Substring(0, 2))
                        };
                    }
                    break;
                default:
                    {
                        result.Complete = true;
                        result.Result = new MeterPointAdministrationNumber{
                            Mpan = mpan,
                            SupplyPointRef = mpan
                        };
                    }
                break;
            }
            result.Message = string.Empty;            
            return result;
        }
    }
}