using System;
using Xunit;
using UnitTestDemo;


namespace TestProject
{
    public class PrimeTests
    {
        [Fact]
        public void PrimeTest1()
        {
            bool expected = true;

            bool result = Utilities.IsPrime(2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PrimeTest2()
        {
            bool expected = true;

            bool result = Utilities.IsPrime(3);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PrimeTest3()
        {
            bool expected = false;

            bool result = Utilities.IsPrime(1);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(6)]
        public void EvenNotPrimeTheory(int input)
        {
            bool result = !Utilities.IsPrime(input);
            Assert.Equal(input%2==0, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(2)]
        public void ReturnsBoolTheory(int input)
        {
            bool result = !Utilities.IsPrime(input);
            Assert.True(result.GetType() == typeof(bool));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void IsPrimeTheories(int input)
        {
            bool result = Utilities.IsPrime(input);
            Assert.True(result);
        }
    }
}
