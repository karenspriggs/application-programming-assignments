using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MansionExplorationGame.Items;

public enum LevelType
{
    TrueFalse,
    MultipleChoice
}

namespace MansionExplorationGame.Level
{
    public static class LevelFactory
    {
        public static ILevel CreateLevel(LevelType levelType, ItemType itemType, string itemName, string riddleID, int floor, string name, string bossDesc)
        {
            ILevel level;

            switch (levelType)
            {
                case (LevelType.TrueFalse):
                    level = new TrueFalseLevel(riddleID);
                    break;
                case (LevelType.MultipleChoice):
                    level = new MultiChoiceLevel(riddleID);
                    break;
                default: throw new ArgumentException("Invalid riddle type?? somehow");
            }

            level.Name = name;
            level.FloorNumber = floor;
            level.Boss = bossDesc;
            level.FloorItem = ItemFactory.CreateItem(itemType, itemName);

            return level;
        }
    }
}
