using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Decorators;
using CPUBattleApp.Items;

namespace CPUBattleApp.Characters
{
    public class Character : ICharacter
    {
        // Character properties
        [NameLength(MaxLength = 10, MinLength = 1)]
        public string Name { get; set; }

        [InventoryLength(Length = 2)]
        public List<IItem> Inventory { get; set; }

        [UniformColor(UniformColors = "blue green yellow purple")]
        public string UniformColor { get; set; }

        public ConsoleColor UniformTextColor { get; set; }

        [GemName(GemTypes = "sapphire diamond ruby")]
        public string GemName { get; set; }
        
        public Gem PlayerGem { get; set; }

        public int TowerHeight { get; set; } = 0;

        public Character()
        {
            Inventory = new List<IItem>();
        }

        public void Update(Wind wind)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            this.TowerHeight -= wind.actualWindDamage;
            Console.WriteLine($"{Name}'s tower was hit by the wind, knocking it down by {wind.actualWindDamage} blocks");
            Console.ResetColor();
        }

        public void DescribeTurn()
        {
            Console.ForegroundColor = UniformTextColor;

            int progress = 0;

            foreach(IItem i in Inventory)
            {
                progress += i.TowerStat;
            }

            TowerHeight += progress;

            Console.WriteLine($"{Name} added {progress} blocks to their tower, making it {TowerHeight} blocks high");

            Console.ResetColor();
        }
    }
}
