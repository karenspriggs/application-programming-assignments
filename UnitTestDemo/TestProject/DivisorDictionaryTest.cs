using System;
using Xunit;
using UnitTestDemo;
using System.Collections.Generic;

namespace TestProject
{
    public class DivisorDictionaryTest
    {
        [Fact]
        public void DivisorDictTest1()
        {
            Dictionary<int,int> expected = new Dictionary<int, int>() { {1, 1 }, { 3, 4 }, { 5, 6 }, { 7, 12 } };

            Dictionary<int, int> result = Utilities.MakeOddDictionary(12);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivisorDictTest2()
        {
            Dictionary<int, int> expected = new Dictionary<int, int>() { { 1, 1 } };

            Dictionary<int, int> result = Utilities.MakeOddDictionary(2);


            Assert.Equal(expected, result);
        }

        [Fact]
        public void DivisorDictTest3()
        {
            Dictionary<int, int> expected = new Dictionary<int, int>() { { 1, 1 }, { 3, 4 }, { 5, 8 }};

            Dictionary<int, int> result = Utilities.MakeOddDictionary(8);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(6)]
        public void OnlyOddKeysTheory(int input)
        {
            bool foundEvenKey = false;
            Dictionary<int, int> result = Utilities.MakeOddDictionary(input);

            foreach(KeyValuePair<int, int> pair in result)
            {
                if (pair.Key % 2 == 0)
                {
                    foundEvenKey = true;
                }
            }

            Assert.False(foundEvenKey);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(2)]
        public void AlwaysContainsOneIfNotZeroTheory(int input)
        {
            Dictionary<int, int> result = Utilities.MakeOddDictionary(input);
            Assert.True(result.ContainsValue(1));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void AllDivisorsNonPrimeTheory(int input)
        {
            bool foundPrimeValue = false;
            Dictionary<int, int> result = Utilities.MakeOddDictionary(input);

            foreach (KeyValuePair<int, int> pair in result)
            {
                if (Utilities.IsPrime(pair.Value))
                {
                    foundPrimeValue = true;
                }
            }

            Assert.False(foundPrimeValue);
        }
    }
}
