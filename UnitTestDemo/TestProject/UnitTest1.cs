using System;
using Xunit;
using UnitTestDemo;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void FloorTest()
        {

        }

        [Theory]
        [InlineData("John", "Arbuckle", "John, Arbuckle")]
        public void TheoryNameTest1(string name1, string name2, string expected)
        {
            string result = Utilities.NameJoiner(name1, name2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StringHasherTest()
        {

        }
    }
}
