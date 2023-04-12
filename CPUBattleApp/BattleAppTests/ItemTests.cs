using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Items;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace BattleAppTests
{
    public class ItemTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ItemConstructorTowerStatTest(int value)
        {
            Item i = new Item("Default", value);
            Assert.Equal(value, i.TowerStat);
        }

        [Theory]
        [InlineData("Test1")]
        [InlineData("Test2")]
        [InlineData("Test3")]
        public void ItemConstructorNameTest(string value)
        {
            Item i = new Item(value);
            Assert.Equal(value, i.Name);
        }

        [Fact]
        public void ItemConstructorIsNotNull()
        {
            Item i = new Item("Default");
            Assert.True(i != null);
            Assert.True(i.GetType() == typeof(Item));
        }
    }
}
