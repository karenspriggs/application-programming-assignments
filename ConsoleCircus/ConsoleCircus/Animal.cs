using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircus
{
    abstract class Animal: IMammal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        public Animal(string _name, int _age)
        {
            this.Name = _name;
            this.Age = _age;
        }

        public string GetInfo()
        {
            return $"{Name} is a {Species} that is {Age} years old";
        }

        public virtual string PerformTrick()
        {
            return $"{Name} the {Species} performed a trick!";
        }
    }
}
