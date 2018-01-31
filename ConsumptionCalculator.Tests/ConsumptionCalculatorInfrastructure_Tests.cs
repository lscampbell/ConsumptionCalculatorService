using System;
using Xunit;
using EnergyBuyer.ConsumptionCalculator.Infrastructure;

namespace ConsumptionCalculator.Tests
{
    public class ConsumptionCalculatorInfrastructure_Tests
    {
        [Fact]
        public void ReturnFalseGivenValueLengthLessThan12InLength()
        {
            string value = "143234";
            var result = MpanParser.Split(value);
            Assert.False(result.Complete, $"{value} should not be mpan");
        }

        [Fact]
        public void ReturnTrueGivenValueLengthGreaterThan12InLength()
        {
            string value = "1900033146143";
            var result = MpanParser.Split(value);
            Assert.True(result.Complete, $"{value} should not be mpan");
        }

        [Fact]
        public void ReturnCorrectCheckDigit()
        {
            string value = "1900033146143";
            var result = MpanParser.Split(value);
            var expected = "143";
            Assert.Equal(expected, result.Result.CheckDigit);
        }

        [Theory]
        [InlineData("1900033146143", 19)]
        public void ReturnCorrectDistributionId(string mpan, int expected)
        {
            var result = MpanParser.Split(mpan);
            Assert.Equal(expected, result.Result.DistributionId);
        }

        [Fact]
        public void ReturnCorrectResult()
        {
            string value = "009998071900033146143";
            var result = MpanParser.Split(value);

            Assert.Equal(result.Result.Mpan, "009998071900033146143");
            Assert.Equal(result.Result.SupplyPointRef, "1900033146143");
            Assert.Equal(result.Result.ProfileType, "00");
            Assert.Equal(result.Result.MeterTimeSwitchCode, "999");
            Assert.Equal(result.Result.LLF, "807");
            Assert.Equal(result.Result.DistributionId, 19);
            Assert.Equal(result.Result.UniqueIdentifer, "00033146");
            Assert.Equal(result.Result.CheckDigit, "143");
        }

        [Theory]
        [InlineData(19, "SEEB")]
        [InlineData(10, "EELC")]
        [InlineData(16, "NORW")]
        [InlineData(12, "LOND")]
        public void ShouldReturnCorrectMarketParticipantId(int distributionId, string expected)
        {
            var result = MpanHelper.GetMarketParticipantId(distributionId);
            Assert.Equal(expected, result);
        }
    }
}