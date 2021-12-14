using FluentAssertions;
using Xunit;

namespace ChristmasLight.Tests
{
    
    public class LightGroupTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(999, 0)]
        [InlineData(0, 999)]
        [InlineData(999, 999)]
        public void BulbsAtPositionsAreOffByDefault(int x, int y)
        {
            LightGroup lightGroup = new LightGroup();
            lightGroup.At(x, y).Status().Should().Be(0);
        }

        [Fact]
        public void AllBulbsAreOnWhenInstructionsAre499_499_500_500()
        {
            LightGroup lightGroup = new LightGroup();

            lightGroup.Instruction(
                new Coordinate(499, 499),
                new Coordinate(500, 500));

            lightGroup.At(499, 499).Status().Should().Be(1);
            lightGroup.At(499, 500).Status().Should().Be(1);
            lightGroup.At(500, 499).Status().Should().Be(1);
            lightGroup.At(500, 500).Status().Should().Be(1);
        }
    }
}