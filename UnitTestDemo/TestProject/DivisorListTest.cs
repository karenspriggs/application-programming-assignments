using System;
using Xunit;
using UnitTestDemo;
using System.Collections.Generic;

namespace TestProject
{
    public class DivisorListTest
    {
        [Fact]
        public void DivisorTest1()
        {
            List<int> expected = new List<int>() { 1};

            List<int> result = Utilities.GetAllNonPrimeDivisors(2);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivisorTest2()
        {
            List<int> expected = new List<int>() { 1,4,6,12};

            List<int> result = Utilities.GetAllNonPrimeDivisors(12);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivisorTest3()
        {
            List<int> expected = new List<int>() { 1 };

            List<int> result = Utilities.GetAllNonPrimeDivisors(5);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(6)]
        public void ContainsOneTheory(int input)
        {
            List<int> result = Utilities.GetAllNonPrimeDivisors(input);
            Assert.Contains(1, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(2)]
        public void ListNotEmptyIfNotZeroTheory(int input)
        {
            int result = Utilities.GetAllNonPrimeDivisors(input).Count;
            Assert.True(result > 0);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void HasOneOnlyIfPrimeTheory(int input)
        {
            int result = Utilities.GetAllNonPrimeDivisors(input).Count;
            Assert.Equal(1, result);
        }
    }
}
