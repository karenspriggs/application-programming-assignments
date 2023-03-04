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
            Console.WriteLine("It is time for the circus to begin!\n");

            foreach(var performer in circusMammals)
            {
                if (performer.GetType().BaseType == typeof(Animal))
                {
                    Console.WriteLine(((Animal)performer).GetInfo());
                }

                if (performer.GetType() == typeof(Human))
                {
                    Console.WriteLine(((Human)performer).GetInfo());
                }

                Console.WriteLine($"{performer.PerformTrick()}\n");
            }
        }

        public void PrintTypes()
        {
            Console.WriteLine("\nHere are the animals that implement the mammal interface but not the abstract animal class");
            var performersWNoAnimalBase = circusMammals.Where(animal => animal.GetType().BaseType != typeof(Animal) && animal.GetType().GetInterfaces().Contains(typeof(IMammal)));

            foreach(var performerWNoAnimalBase in performersWNoAnimalBase)
            {
                Console.WriteLine(performerWNoAnimalBase.GetType());
            }
        }

        public void PerformShow()
        {
            PrintShow();
            PrintTypes();
            Console.WriteLine("\nThe circus is over! Thank you for coming.");
            Console.ReadKey();
        }
    }
}
