using System;
using Xunit;
using UnitTestDemo;


namespace TestProject
{
    public class FractionFloorTests
    {
        [Fact]
        public void FloorFracTest1()
        {
            double expected = 2;
            double result = Utilities.GetFloorOfFraction(5, 2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloorFracTest2()
        {
            double expected = 3;
            double result = Utilities.GetFloorOfFraction(7, 2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloorFracTest3()
        {
            double expected = 3;
            double result = Utilities.GetFloorOfFraction(31,10);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(10,3)]
        [InlineData(20,6)]
        [InlineData(30,8)]
        public void NotLargerThanNumeratorTheory(int input1, int input2)
        {
            double result = Utilities.GetFloorOfFraction(input1, input2);
            Assert.True(result < input1);
        }

        [Theory]
        [InlineData(10, 3)]
        [InlineData(20, 6)]
        [InlineData(30, 8)]
        public void BiggerThanZeroTheory(int input1, int input2)
        {
            double result = Utilities.GetFloorOfFraction(input1, input2);
            Assert.True(result > 0);
        }

        [Theory]
        [InlineData(10, 3)]
        [InlineData(20, 6)]
        [InlineData(30, 8)]
        public void ReturnsDoubleTheory(int input1, int input2)
        {
            double result = Utilities.GetFloorOfFraction(input1, input2);
            Assert.True(result.GetType() == typeof(double));
        }
    }
}
