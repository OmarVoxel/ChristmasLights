using System;
using Xunit;
using FluentAssertions;
using FluentAssertions.Equivalency.Tracing;

namespace ChristmasLight.Tests
{
    public class ChristmasTests
    {
        [Fact]
        public void BulbIsOff()
        {
            Bulb bulb = new Bulb();
            bulb.Status().Should().Be(0);
        }

        [Fact]
        public void BulbIsOn()
        {
            Bulb bulb = new Bulb();
            bulb.TurnOn();
            bulb.Status().Should().Be(1);
        }
        
        [Fact]
        public void BulbIsOffThenOnThenOff()
        {
            Bulb bulb = new Bulb();
            bulb.Status().Should().Be(0);
            bulb.TurnOn();
            bulb.Status().Should().Be(1);
            bulb.TurnOff();
            bulb.Status().Should().Be(0);
        }
    }
}