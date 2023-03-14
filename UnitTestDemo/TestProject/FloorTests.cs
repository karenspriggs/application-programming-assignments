using System;
using Xunit;
using UnitTestDemo;

namespace TestProject
{
    public class FloorTests
    {
        [Fact]
        public void FloorTest1()
        {
            double expected = 2;
            double result = Utilities.GetFloorForDouble(2.22);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloorTest2()
        {
            double expected = 4;
            double result = Utilities.GetFloorForDouble(4.65);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FloorTest3()
        {
            double expected = 6;
            double result = Utilities.GetFloorForDouble(6.83);
            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData(8.44)]
        [InlineData(4.33)]
        [InlineData(6.33)]
        public void NotLargerThanInputTheory(double input)
        {
            double result = Utilities.GetFloorForDouble(input);
            Assert.True(result < input);
        }

        [Theory]
        [InlineData(8.44)]
        [InlineData(4.33)]
        [InlineData(6.33)]
        public void EqualsCielOfPreviousTheory(double input)
        {
            double expected = Math.Ceiling(input - 1);
            double result = Utilities.GetFloorForDouble(input);
            Assert.True(result == expected);
        }

        [Theory]
        [InlineData(8.44)]
        [InlineData(4.33)]
        [InlineData(6.33)]
        public void ReturnsDoubleTheory(double input)
        {
            double result = Utilities.GetFloorForDouble(input);
            Assert.True(result.GetType() == typeof(double));
        }
    }
}
