using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunProblems
{
    public class RiverCrossing
    {
        List<Person> LeftBank = new List<Person>();
        List<Person> rightBank = new List<Person>();

        int totalTime = 0;

        public RiverCrossing()
        {
            rightBank.Add(new Person(3, "Friend A"));
            rightBank.Add(new Person(6, "Friend B"));
            rightBank.Add(new Person(7, "Friend C"));
            rightBank.Add(new Person(9, "Friend D"));

            Start();
            Console.ReadKey();
        }

        void Start()
        {
            while (rightBank.Count > 1)
            {
                GoToBank(rightBank, LeftBank);
                GoToBank(LeftBank, rightBank);
            }

            PrintStatus();
        }

        void GoToBank(List<Person> fromBank, List<Person> toBank)
        {
            if (rightBank.Count == 0) return;
            PrintStatus();

            int fastestSpeed = 10;
            int slowestSpeed = 0;

            foreach (Person p in fromBank)
            {
                if (p.speed < fastestSpeed)
                {
                    fastestSpeed = p.speed;
                }

                if (p.speed > slowestSpeed)
                {
                    slowestSpeed = p.speed;
                }
            }

            Person fastestPerson = new Person();
            Person slowestPerson = new Person();

            foreach (Person p in fromBank)
            {
                if (p.speed == fastestSpeed)
                {
                    fastestPerson = p;
                }

                if (p.speed == slowestSpeed)
                {
                    slowestPerson = p;
                }
            }

            fromBank.Remove(fastestPerson);
            
            if (fromBank == rightBank)
            {
                fromBank.Remove(slowestPerson);
            }
            
            toBank.Add(fastestPerson);

            if (fromBank == rightBank)
            {
                toBank.Add(slowestPerson);
            }

            if (fromBank == LeftBank)
            {
                slowestSpeed = fastestSpeed;
            }

            totalTime += slowestSpeed;

            if (fromBank == rightBank)
            {
                Console.WriteLine($"{fastestPerson.name} {slowestPerson.name} went to the left bank at the speed of {slowestSpeed}\nTotal time: {totalTime}");
            }
            else
            {
                Console.WriteLine($"{fastestPerson.name} went to the right bank at the speed of {slowestSpeed}\nTotal time: {totalTime}");
            }
        }

        void PrintStatus()
        {
            string rightBankContents = "";
            string leftBankContents = "";

            foreach(Person p in rightBank)
            {
                rightBankContents += $" {p.name}";
            }

            foreach (Person p in LeftBank)
            {
                leftBankContents += $" {p.name}";
            }

            Console.WriteLine($"Current locations:\nLeft Bank:{leftBankContents}\nRight Bank:{rightBankContents}");
        }
    }

    public class Person
    {
        public int speed;
        public string name;

        public Person()
        {

        }

        public Person(int _speed, string _name)
        {
            speed = _speed;
            name = _name;
        }
    }
}
