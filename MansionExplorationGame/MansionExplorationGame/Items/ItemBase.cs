using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame.Items
{
    public abstract class ItemBase : IItem
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual string Describe()
        {
            return $"The {Name} {Type}";
        }
    }
}
