using System;
using Xunit;
using MansionExplorationGame;

namespace MansionTests
{
    public class SingletonTests
    {
        [Fact]
        public void LivesTest()
        {
            PlayerLives.Instance.ResetLives();
            Assert.Equal("You have 5 lives left", PlayerLives.Instance.PrintLives());
            PlayerLives.Instance.DepleteLife();
            Assert.Equal("You have 4 lives left", PlayerLives.Instance.PrintLives());
            PlayerLives.Instance.DepleteLife();
            Assert.Equal("You have 3 lives left", PlayerLives.Instance.PrintLives());
        }

        [Fact]
        public void TimerTest()
        {
            Timer.Instance.PrintTimer();
            Assert.Equal("Time left: 5:0", Timer.Instance.PrintTimer());
        }
    }
}
