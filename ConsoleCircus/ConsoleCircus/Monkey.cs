using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircus
{
    class Monkey : Animal
    {
        public Monkey() : base()
        {
            this.Species = "Monkey";
        }

        public Monkey(string _name, int _age):base(_name, _age)
        {
            this.Species = "Monkey";
        }

        public override string PerformTrick()
        {
            return $"{Name} the {Species} did a handstand while juggling with their feet!";
        }
    }
}
