using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUBattleApp.Items;

namespace CPUBattleApp.Characters
{
    public interface ICharacter
    {
        string Name { get; set; }
        string UniformColor { get; set; }
        List<IItem> Inventory { get; set; }
        ConsoleColor UniformTextColor { get; set; }
        Gem PlayerGem { get; set; }
        int TowerHeight { get; set; }

        void Update(Wind wind);
        void DescribeTurn();
    }
}
