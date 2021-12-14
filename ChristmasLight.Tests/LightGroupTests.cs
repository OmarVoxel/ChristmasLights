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

            lightGroup.Instruction(499, 499, 500, 500);

            lightGroup.At(499, 499).Should().Be(1);
            lightGroup.At(499, 500).Should().Be(1);
            lightGroup.At(500, 499).Should().Be(1);
            lightGroup.At(500, 500).Should().Be(1);
        }
    }
}