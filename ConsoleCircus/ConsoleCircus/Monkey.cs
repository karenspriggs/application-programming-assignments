using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircus
{
    class Monkey : Animal
    {
        public Monkey(string _name, int _age):base(_name, _age)
        {
            this.Species = "Monkey";
        }
    }
}
