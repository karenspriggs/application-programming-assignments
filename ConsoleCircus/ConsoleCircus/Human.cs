using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircus
{
    // People are animals i know but idc
    class Human : IMammal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        public Human()
        {

        }

        public void PerformTrick()
        {

        }
    }
}
