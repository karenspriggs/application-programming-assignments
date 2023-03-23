using System;
using Xunit;
using MansionExplorationGame.Items;
using MansionExplorationGame;

namespace MansionTests
{
    public class ItemTests
    {
        [Fact]
        public void PotionTest()
        {
            IItem Item = ItemFactory.CreateItem(ItemType.Potion, "Test");
            Assert.True(Item.GetType() == typeof(Potion));
            Assert.Equal("Test", Item.Name);
        }

        [Fact]
        public void CoinTest()
        {
            IItem Item = ItemFactory.CreateItem(ItemType.Coin, "Test");
            Assert.True(Item.GetType() == typeof(Coin));
            Assert.Equal("Test", Item.Name);
        }

        [Fact]
        public void FoodTest()
        {
            IItem Item = ItemFactory.CreateItem(ItemType.Food, "Test");
            Assert.True(Item.GetType() == typeof(Food));
            Assert.Equal("Test", Item.Name);
        }
    }
}
