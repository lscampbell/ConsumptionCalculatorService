using EnergyBuyer.ConsumptionProducer;
using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using Shouldly;
using System.Linq;

namespace ConsumptionProducer.Tests
{
    public class ConsumptionData_Tests
    {
        // [Theory]
        // [MemberData(nameof(Get), MemberType= typeof(ConsumptionData))]
        [Fact]
        public void BigTest(Consumption expected)
        {
            var data = ConsumptionData.Get()
        }
    }
}