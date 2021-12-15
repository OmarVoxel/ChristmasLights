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


        [Fact]
        public void InstructionsRequestedSequences()
        {
            LightGroup lightGroup = new LightGroup();
            
            lightGroup.Instruction(
                new Coordinate(887, 9),
                new Coordinate(959, 629),
                Instructions.TurnOn);

            lightGroup.Instruction(
                new Coordinate(454, 398),
                new Coordinate(844, 448),
                Instructions.TurnOn);
            
            lightGroup.Instruction(
                new Coordinate(539, 243),
                new Coordinate(559, 965),
                Instructions.TurnOff);
            
            lightGroup.Instruction(
                new Coordinate(370, 819),
                new Coordinate(676, 868),
                Instructions.TurnOff);
            
            lightGroup.Instruction(
                new Coordinate(145, 40),
                new Coordinate(370, 997),
                Instructions.TurnOff);

            lightGroup.Instruction(
                new Coordinate(301, 3),
                new Coordinate(808, 453),
                Instructions.TurnOff);
            
            lightGroup.Instruction(
                new Coordinate(351, 678),
                new Coordinate(951, 908),
                Instructions.TurnOn);
            
            lightGroup.Instruction(
                new Coordinate(720, 196),
                new Coordinate(897, 994),
                Instructions.Toggle);
            
            lightGroup.Instruction(
                new Coordinate(831, 394),
                new Coordinate(904, 860),
                Instructions.Toggle);
            
            lightGroup.CountBulbOn().Should().Be(230022);
        }
    }
}