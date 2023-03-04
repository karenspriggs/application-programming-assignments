using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircus
{
    interface IMammal
    {
        string Name { get; set; }
        string Species { get; set; }
        int Age { get; set; }

        string PerformTrick();
    }
}
