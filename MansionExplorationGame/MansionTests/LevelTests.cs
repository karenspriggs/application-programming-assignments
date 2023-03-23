using System;
using Xunit;
using MansionExplorationGame.Level;

namespace MansionTests
{
    public class LevelTests
    {
        [Fact]
        public void MultiChoiceLevelTest()
        {
            ILevel level = LevelFactory.CreateLevel(LevelType.MultipleChoice, ItemType.Potion, "Test", "circle", 1, "Test", "TestBoss");
            Assert.Equal("TestBoss", level.Boss);
            Assert.Equal("Test", level.Name);
            Assert.Equal(1, level.FloorNumber);
            Assert.True(level.GetType() == typeof(MultiChoiceLevel));
            Assert.True(level.CompareAnswer("1"));
        }

        [Fact]
        public void TrueFalseLevelTest()
        {
            ILevel level = LevelFactory.CreateLevel(LevelType.TrueFalse, ItemType.Coin, "Test", "house", 2, "Test1", "TestBoss1");
            Assert.Equal("TestBoss1", level.Boss);
            Assert.Equal("Test1", level.Name);
            Assert.Equal(2, level.FloorNumber);
            Assert.True(level.GetType() == typeof(TrueFalseLevel));
            Assert.True(level.CompareAnswer("false"));
        }
    }
}
