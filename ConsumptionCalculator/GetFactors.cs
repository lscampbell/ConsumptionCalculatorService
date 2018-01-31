using System;
using System.Collections.Generic;
using System.Linq;
using EnergyBuyer.ConsumptionCalculator.Entities;

namespace EnergyBuyer.ConsumptionCalculator
{
    public class GetFactors
    {
        public Factors Results = new Factors();
        public GetFactors(string marketParticipantId, string llf, string date, string startTime)
        {
            Results = new Factors {
                DistributionFactor = DistributionData
                        .Where(
                            w => w.LLF == llf && 
                            w.MarketParticipantId == marketParticipantId &&
                            // w.Date == date &&
                            w.StartTime == startTime)
                        .FirstOrDefault(),
                TransmissionFactor =  TransmissionData
            };
        }
        public Transmission TransmissionData => new Transmission { Date = "2012-01-01", Factor = 1.01F };
        public IEnumerable<Distribution> DistributionData => new List<Distribution> {
            new Distribution { Date = "2012-01-01", StartTime = "00:00:00", EndTime = "00:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "00:30:00", EndTime = "01:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "01:00:00", EndTime = "01:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "01:30:00", EndTime = "02:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "02:00:00", EndTime = "02:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "02:30:00", EndTime = "03:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "03:00:00", EndTime = "03:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "03:30:00", EndTime = "04:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "04:00:00", EndTime = "04:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "04:30:00", EndTime = "05:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "05:00:00", EndTime = "05:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "05:30:00", EndTime = "06:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "06:00:00", EndTime = "06:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "06:30:00", EndTime = "07:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "07:00:00", EndTime = "07:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "07:30:00", EndTime = "08:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "08:00:00", EndTime = "08:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "08:30:00", EndTime = "09:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "09:00:00", EndTime = "09:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "09:30:00", EndTime = "10:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "10:00:00", EndTime = "10:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "10:30:00", EndTime = "11:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "11:00:00", EndTime = "11:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "11:30:00", EndTime = "12:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "12:00:00", EndTime = "12:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "12:30:00", EndTime = "13:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "13:00:00", EndTime = "13:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "13:30:00", EndTime = "14:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "14:00:00", EndTime = "14:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "14:30:00", EndTime = "15:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "15:00:00", EndTime = "15:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "15:30:00", EndTime = "16:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "16:00:00", EndTime = "16:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "16:30:00", EndTime = "17:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "17:00:00", EndTime = "17:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "17:30:00", EndTime = "18:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.02F },
            new Distribution { Date = "2012-01-01", StartTime = "18:00:00", EndTime = "18:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "18:30:00", EndTime = "19:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "19:00:00", EndTime = "19:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "19:30:00", EndTime = "20:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.04F },
            new Distribution { Date = "2012-01-01", StartTime = "20:00:00", EndTime = "20:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "20:30:00", EndTime = "21:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "21:00:00", EndTime = "21:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "21:30:00", EndTime = "22:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "22:00:00", EndTime = "22:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "22:30:00", EndTime = "23:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "23:00:00", EndTime = "23:30:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
            new Distribution { Date = "2012-01-01", StartTime = "23:30:00", EndTime = "00:00:00", MarketParticipantId = "SEEB", LLF = "801", Factor = 1.06F },
        };
    }
}