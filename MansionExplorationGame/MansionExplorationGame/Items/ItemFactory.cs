using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ItemType
{
    Potion,
    Food,
    Coin
}

namespace MansionExplorationGame.Items
{
    public static class ItemFactory
    {
        public static IItem CreateItem(ItemType type, string name)
        {
            IItem item;

            switch (type)
            {
                case (ItemType.Potion):
                    item = new Potion(name);
                    break;
                case (ItemType.Food):
                    item = new Food(name);
                    break;
                case (ItemType.Coin):
                    item = new Coin(name);
                    break;
                default: throw new ArgumentException("Invalid item type?? somehow");
            }
            return item;
        }
    }
}
