using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircus
{
    class Circus
    {
        List<IMammal> circusMammals = new List<IMammal>()
        {
            new Monkey("Curious George", 17),
            new Tiger("Shere Khan", 33),
            new Human("Khada Jhin", 41),
            new Monkey("Donkey Kong", 42),
            new Tiger("Rajah", 31),
            new Human("Rakan", 28),
            new Monkey("Winston", 7),
            new Tiger("Jackson", 5),
            new Human("Settrigh", 22)
        };

        public void PrintShow()
        {
            Console.WriteLine("It is time for the circus to begin!");

            foreach(var performer in circusMammals)
            {
                if (performer.GetType().BaseType == typeof(Animal))
                {
                    Console.WriteLine(((Animal)performer).GetInfo());
                }

                if (performer.GetType().BaseType == typeof(Human))
                {
                    Console.WriteLine(((Human)performer).GetInfo());
                }

                Console.WriteLine(performer.PerformTrick());
            }
        }

        public void PrintTypes()
        {
            var performersWAnimalBase = circusMammals.Where(animal => animal.GetType().BaseType == typeof(Animal));

            foreach(var performerWAnimalBase in performersWAnimalBase)
            {
                Console.WriteLine(performerWAnimalBase.GetType());
            }
        }

        public void PerformShow()
        {
            PrintShow();
            PrintTypes();
            Console.ReadKey();
        }
    }
}
