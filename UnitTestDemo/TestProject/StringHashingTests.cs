using System;
using Xunit;
using UnitTestDemo;

namespace TestProject
{
    public class StringHashingTests
    {
        [Fact]
        public void HashTest1()
        {
            string hashedExpected = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";

            string result = Utilities.StringHasher("password");
            Assert.Equal(hashedExpected, result);
        }

        [Fact]
        public void HashTest2()
        {
            string hashedExpected = "ba21767ae494afe5a2165dcb3338c5323e9907050e34542c405d575cc31bf527";

            string result = Utilities.StringHasher("superpassword");
            Assert.Equal(hashedExpected, result);
        }

        [Fact]
        public void HashTest3()
        {
            string hashedExpected = "9f2f5f3157f4a0e95bcb05153e1d2439cfa3646fe8ea973f27287f49e93220b2";

            string result = Utilities.StringHasher("bigsuperpassword");
            Assert.Equal(hashedExpected, result);
        }

        [Theory]
        [InlineData("John")]
        [InlineData("Garfield")]
        [InlineData("Odie")]
        public void NotEmptyTheory(string input)
        {
            string result = Utilities.StringHasher(input);
            Assert.True(result != "");
        }

        [Theory]
        [InlineData("John")]
        [InlineData("Garfield")]
        [InlineData("Odie")]
        public void LengthTheory(string input)
        {
            string result = Utilities.StringHasher(input);
            Assert.True(result.Length == 64);
        }

        [Theory]
        [InlineData("John")]
        [InlineData("Garfield")]
        [InlineData("Odie")]
        public void DifferentOutputTheory(string input)
        {
            string result = Utilities.StringHasher(input);
            Assert.False(result == input);
        }
    }
}
