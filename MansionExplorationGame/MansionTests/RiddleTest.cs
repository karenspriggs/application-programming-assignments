using System;
using Xunit;
using MansionExplorationGame.Riddle;

namespace MansionTests
{
    public class RiddleTest
    {
        [Fact]
        public void RiddleDoesNotExist()
        {
            RiddleB riddle = new RiddleB("Fakeykey");

            Assert.Equal("Default prompt", riddle.Prompt);
            Assert.Equal("Default answer", riddle.Answer);
        }

        [Fact]
        public void RiddleKeyTests()
        {
            RiddleB circleRiddle = new RiddleB("circle");
            RiddleB houseRiddle = new RiddleB("house");

            Assert.Equal("How many sides does a circle have?\n1)Two\n2)One\n3)None", circleRiddle.Prompt);
            Assert.Equal("1", circleRiddle.Answer);

            Assert.Equal("You live in a one story house made entirely of redwood.\nAre your stairs also red (true or false)?", houseRiddle.Prompt);
            Assert.Equal("false", houseRiddle.Answer);
        }
    }
}
