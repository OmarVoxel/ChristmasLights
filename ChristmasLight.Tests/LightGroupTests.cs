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
    }
}