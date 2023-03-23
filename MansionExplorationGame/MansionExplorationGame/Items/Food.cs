using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Items
{
    public class Food: ItemBase
    {
        public Food(string _name)
        {
            this.Name = _name;
            this.Type = "Food";
        }

        public override string Describe()
        {
            return Name;
        }
    }
}
