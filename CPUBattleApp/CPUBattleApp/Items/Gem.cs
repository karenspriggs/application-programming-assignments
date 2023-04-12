using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUBattleApp.Items
{
    public class Gem : Item
    {
        public Gem(string name) : base(name)
        {
            this.Name = name;
            this.Description = $"A {name}";
        }
    }
}
