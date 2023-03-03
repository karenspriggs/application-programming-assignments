using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircus
{
    class Tiger: Animal
    {
        public Tiger(string _name, int _age) : base(_name, _age)
        {
            this.Species = "Tiger";
        }
    }
}
