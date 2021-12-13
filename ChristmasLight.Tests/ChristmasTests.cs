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
    }
}