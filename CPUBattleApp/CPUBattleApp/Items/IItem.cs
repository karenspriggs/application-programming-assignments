using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUBattleApp.Items
{
    public interface IItem
    {
        string Name { get; set; }
        string Description { get; set; }
        int TowerStat { get; set; }
        void Describe();
    }
}
