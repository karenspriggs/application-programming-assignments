using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MansionExplorationGame
{
    public interface IItem
    {
        string Name { get; set; }
        string Type { get; set; }
        string Describe();
    }
}
