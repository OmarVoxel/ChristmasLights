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
                new Coordinate(500, 500),
                Instructions.TurnOn);

            lightGroup.At(499, 499).Status().Should().Be(1);
            lightGroup.At(499, 500).Status().Should().Be(1);
            lightGroup.At(500, 499).Status().Should().Be(1);
            lightGroup.At(500, 500).Status().Should().Be(1);
        }
        
        [Fact]
        public void OneMillionBulbsAreOn()
        {
            LightGroup lightGroup = new LightGroup();

            lightGroup.Instruction(
                new Coordinate(0, 0),
                new Coordinate(999, 999),
                Instructions.TurnOn);

            lightGroup.CountBulbOn().Should().Be(1000000);
        }
        
        [Fact]
        public void FourBulbsAreOn()
        {
            LightGroup lightGroup = new LightGroup();

            lightGroup.Instruction(
                new Coordinate(499, 499),
                new Coordinate(500, 500),
                Instructions.TurnOn);

            lightGroup.CountBulbOn().Should().Be(4);
        }
        
        
        [Fact]
        public void InstructionsSequences()
        {
            LightGroup lightGroup = new LightGroup();

            lightGroup.Instruction(
                new Coordinate(499, 499),
                new Coordinate(500, 500),
                Instructions.Toggle);
    
            lightGroup.Instruction(
                new Coordinate(499, 499),
                new Coordinate(500, 500),
                Instructions.Toggle);
            
            lightGroup.CountBulbOn().Should().Be(0);
        }
        
    }
}