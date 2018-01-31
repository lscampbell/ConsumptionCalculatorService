using System;
using Xunit;
using EnergyBuyer.ConsumptionCalculator;
using EnergyBuyer.ConsumptionCalculator.Entities;
using FluentAssertions;
using System.Collections.Generic;
using Shouldly;
using System.Linq;

namespace EnergyBuyer.ConsumptionCalculator.Tests
{
    public class ConsumptionCalculator_Tests
    {
        Distribution _expectedDis;
        Transmission _expectedTra;
        public ConsumptionCalculator_Tests()
        {
            _expectedDis =
                new Distribution 
                    { 
                        Date = "2012-01-01", 
                        StartTime = "00:00:00", 
                        EndTime = "00:30:00", 
                        MarketParticipantId = "LOND", 
                        LLF = "801", 
                        Factor = 1.02F
                    };

            _expectedTra = 
                new Transmission 
                    { 
                        Date = "2012-01-01", 
                        Factor = 1.01F
                    };
        }

        [Theory]
        [InlineData("LOND", "801", "2012-01-01", "00:00:00")]
        public void ShouldReturnCorrectDistributionFactors(string marketParticipantId, string llf, string date, string startTime)
        {
            var actual = new GetFactors(marketParticipantId, llf, date, startTime);
            actual.Results.DistributionFactor.Should().BeEquivalentTo(_expectedDis);
        }

        [Theory]
        [InlineData("LOND", "801", "2012-01-01", "00:30:00")]
        public void ShouldReturnIncorrectDistributionFactors(string marketParticipantId, string llf, string date, string startTime)
        {
            var actual = new GetFactors(marketParticipantId, llf, date, startTime);
            actual.Results.DistributionFactor.Should().NotBe(_expectedDis);
        }

        [Theory]
        [InlineData("LOND", "801", "2012-01-01", "00:00:00")]
        public void ShouldReturnCorrectTransmissionFactors(string marketParticipantId, string llf, string date, string startTime)
        {
            var actual = new GetFactors(marketParticipantId, llf, date, startTime);;
            actual.Results.TransmissionFactor.Should().BeEquivalentTo(_expectedTra);
        }

        [Theory]
        [InlineData("LOND", "801", "2012-01-01", "00:30:00")]
        public void ShouldReturnIncorrectTransmissionFactors(string marketParticipantId, string llf, string date, string startTime)
        {
            var actual = new GetFactors(marketParticipantId, llf, date, startTime);;
            actual.Results.TransmissionFactor.Should().NotBe(_expectedTra);
        }

        [Theory]
        [InlineData(9.359991, 234, 1.04)]
        [InlineData(20.99998, 700, 1.03)]
        [InlineData(90.00003, 1000, 1.09)]
        public void ShouldReturnCorrectCalculations(float expected, int kwh, float factor)
        {
            var actual = new Calculate();
            Assert.Equal(expected, actual.Calculation(kwh, factor));
        }
        
        [Theory]
        [InlineData(9.359991, 234, 1.05)]
        [InlineData(9.359991, 700, 1.03)]
        [InlineData(9.359991, 1000, 1.09)]
        public void ShouldReturnIncorrectCalculations(float expected, int kwh, float factor)
        {
            var actual = new Calculate();
            Assert.NotEqual(expected, actual.Calculation(kwh, factor));
        }
    }
}
