using System.Collections.Generic;
using System.Linq;
using EnergyBuyer.ConsumptionCalculator.Entities;

namespace EnergyBuyer.ConsumptionCalculator.Infrastructure
{
    public static class MpanHelper
    {
        public static string GetMarketParticipantId(int id) 
            => _list
                .Where(w => w.DistributionId == id)
                .FirstOrDefault().MarketParticipantId;

        static List<DistributionNetworkOperator> _list = 
            new List<DistributionNetworkOperator>{
                new DistributionNetworkOperator 
                    { DistributionId = 10, DistributionName = "Eastern England",                Operator = "UK Power Networks",             MarketParticipantId = "EELC", GSPGroupId = "_A" },
                new DistributionNetworkOperator 
                    { DistributionId = 11, DistributionName = "East Midlands",                  Operator = "Western Power Distribution",    MarketParticipantId = "EMEB", GSPGroupId = "_B" },
                new DistributionNetworkOperator 
                    { DistributionId = 12, DistributionName = "London",                         Operator = "UK Power Networks",             MarketParticipantId = "LOND", GSPGroupId = "_C" },
                new DistributionNetworkOperator 
                    { DistributionId = 13, DistributionName = "Merseyside and Northern Wales",  Operator = "ScottishPower",                 MarketParticipantId = "MANW", GSPGroupId = "_D" },
                new DistributionNetworkOperator 
                    { DistributionId = 14, DistributionName = "West Midlands",                  Operator = "Western Power Distribution",    MarketParticipantId = "MIDE", GSPGroupId = "_E" },
                new DistributionNetworkOperator 
                    { DistributionId = 15, DistributionName = "North Eastern England",          Operator = "Northern Powergrid",            MarketParticipantId = "NEEB", GSPGroupId = "_F" },
                new DistributionNetworkOperator 
                    { DistributionId = 16, DistributionName = "North Western England",          Operator = "Electricity North West",        MarketParticipantId = "NORW", GSPGroupId = "_G" },
                new DistributionNetworkOperator 
                    { DistributionId = 17, DistributionName = "Northern Scotland",              Operator = "SSE Power Distribution",        MarketParticipantId = "HYDE", GSPGroupId = "_P" },
                new DistributionNetworkOperator 
                    { DistributionId = 18, DistributionName = "Southern Scotland",              Operator = "ScottishPower",                 MarketParticipantId = "SPOW", GSPGroupId = "_N" },
                new DistributionNetworkOperator 
                    { DistributionId = 19, DistributionName = "South Eastern England",          Operator = "UK Power Networks",             MarketParticipantId = "SEEB", GSPGroupId = "_J" },
                new DistributionNetworkOperator 
                    { DistributionId = 20, DistributionName = "Southern England",               Operator = "SSE Power Distribution",        MarketParticipantId = "SOUT", GSPGroupId = "_H" },
                new DistributionNetworkOperator 
                    { DistributionId = 21, DistributionName = "Southern Wales",                 Operator = "Western Power Distribution",    MarketParticipantId = "SWAE", GSPGroupId = "_K" },
                new DistributionNetworkOperator 
                    { DistributionId = 22, DistributionName = "South Western England",          Operator = "Western Power Distribution",    MarketParticipantId = "SWEB", GSPGroupId = "_L" },
                new DistributionNetworkOperator 
                    { DistributionId = 23, DistributionName = "Yorkshire",                      Operator = "Northern Powergrid",            MarketParticipantId = "YELG", GSPGroupId = "_M" }
        };
    }
}