using System;
using Xunit;
using UnitTestDemo;

namespace TestProject
{
    public class NameJoinerTest
    {
        [Fact]
        public void NameTest1()
        {
            string firstName = "Ace";
            string lastName = "Ukiyoe";

            string result = Utilities.NameJoiner(firstName, lastName);
            Assert.Equal("Ace, Ukiyoe", result);
        }

        [Fact]
        public void NameTest2()
        {
            string firstName = "Neon";
            string lastName = "Kuruma";

            string result = Utilities.NameJoiner(firstName, lastName);
            Assert.Equal("Neon, Kuruma", result);
        }

        [Fact]
        public void NameTest3()
        {
            string firstName = "Sakurai";
            string lastName = "Keiwa";

            string result = Utilities.NameJoiner(firstName, lastName);
            Assert.Equal("Sakurai, Keiwa", result);
        }

        [Theory]
        [InlineData("John", "Arbuckle")]
        [InlineData("Garfield", "Arbuckle")]
        [InlineData("Odie", "Arbuckle")]
        public void NotEmptyTheory(string name1, string name2)
        {
            string result = Utilities.NameJoiner(name1, name2);
            Assert.True(result != "");
        }

        [Theory]
        [InlineData("John", "Arbuckle")]
        [InlineData("Garfield", "Arbuckle")]
        [InlineData("Odie", "Arbuckle")]
        public void LengthTheory(string name1, string name2)
        {
            int length = 0;
            length += name1.Length;
            length += name2.Length;
            // For the space and the comma
            length += 2;
            string result = Utilities.NameJoiner(name1, name2);
            Assert.Equal(result.Length, length);
        }

        [Theory]
        [InlineData("John", "Arbuckle")]
        [InlineData("Garfield", "Arbuckle")]
        [InlineData("Odie", "Arbuckle")]
        public void ConcatTheory(string name1, string name2)
        {
            string result = Utilities.NameJoiner(name1, name2);
            Assert.Equal(result, $"{name1}, {name2}");
        }
    }
}
