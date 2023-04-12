using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUBattleApp.Items
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TowerStat { get; set; }

        public Item(string name)
        {
            Name = name;
        }

        public Item(string name, int towerStat)
        {
            Name = name;
            TowerStat = towerStat;
        }

        public void Describe()
        {
            Console.WriteLine($"A {Name}, which makes your tower gain {TowerStat} blocks per turn");
        }
    }
}
