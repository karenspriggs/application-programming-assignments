using System;
using Xunit;
using CPUBattleApp;
using CPUBattleApp.Characters;
using System.ComponentModel.DataAnnotations;

namespace BattleAppTests
{
    public class ObserverWindTest
    {
        [Fact]
        public void AttachListenerTest()
        {
            Character testCharacter1 = new Character();
            Character testCharacter2 = new Character();
            Wind wind = new Wind();
            wind.StartWind(0, 2);

            Assert.Equal(0, wind.GetListenerCount());

            wind.Attach(testCharacter1);

            Assert.Equal(1, wind.GetListenerCount());

            wind.Attach(testCharacter2);

            Assert.Equal(2, wind.GetListenerCount());
        }

        [Fact]
        public void RemoveListenerTest()
        {
            Character testCharacter1 = new Character();
            Character testCharacter2 = new Character();

            Wind wind = new Wind();
            wind.StartWind(0, 2);

            wind.Attach(testCharacter1);
            wind.Attach(testCharacter2);

            Assert.Equal(2, wind.GetListenerCount());

            wind.Remove(testCharacter1);

            Assert.Equal(1, wind.GetListenerCount());

            wind.Remove(testCharacter2);

            Assert.Equal(0, wind.GetListenerCount());
        }

        [Fact]
        public void NotifyListenerTest()
        {
            Character testCharacter1 = new Character();
            Character testCharacter2 = new Character();

            Wind wind = new Wind();
            wind.StartWind(1, 3);

            wind.Attach(testCharacter1);
            wind.Attach(testCharacter2);

            int initialTest1Height = testCharacter1.TowerHeight;
            int initialTest2Height = testCharacter2.TowerHeight;

            wind.Notify();

            Assert.True(initialTest1Height > testCharacter1.TowerHeight);
            Assert.True(initialTest2Height > testCharacter2.TowerHeight);
        }
    }
}
