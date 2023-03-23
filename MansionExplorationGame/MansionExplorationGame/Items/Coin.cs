using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Items
{
    public class Coin : ItemBase
    {
        public Coin(string _name)
        {
            this.Name = _name;
            this.Type = "Coin";
        }
    }
}
