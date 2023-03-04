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

        public Human(string _name, int _age)
        {
            this.Name = _name;
            this.Age = _age;
            this.Species = "Human";
        }

        public string GetInfo()
        {
            return $"{Name} is a human circus performer that is {Age} years old";
        }

        public string PerformTrick()
        {
            return $"{Name} swung over the other performing animals on a trapeze!";
        }
    }
}
