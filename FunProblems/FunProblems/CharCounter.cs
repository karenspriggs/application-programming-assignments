using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunProblems
{
    public class CharCounter
    {
        Dictionary<string, int> charDict = new Dictionary<string, int>();

        public CharCounter(string s)
        {
            AddToDict(s);
            FindMinMax();
        }

        void AddToDict(string s)
        {
            foreach(char c in s)
            {
                if (char.IsLetter(c))
                {
                    if (!charDict.ContainsKey(c.ToString().ToLower()))
                    {
                        charDict.Add(c.ToString().ToLower(), 0);
                    }

                    charDict[c.ToString().ToLower()]++;
                }
            }
        }

        void FindMinMax()
        {
            int min = 1000000;
            int max = 0;

            foreach(KeyValuePair<string, int> pair in charDict)
            {
                if (pair.Value > max)
                {
                    max = pair.Value;
                }
                
                if (pair.Value < min)
                {
                    min = pair.Value;
                }
            }

            PrintMinMax(min, max);
            Console.ReadKey();
        }

        void PrintMinMax(int min, int max)
        {
            string minValues = "Minimum occuring char(s):";
            string maxValues = "Maximum occuring char(s):";

            foreach (KeyValuePair<string, int> pair in charDict)
            {
                if (pair.Value == min)
                {
                    minValues += $" {pair.Key}";
                }

                if (pair.Value == max)
                {
                    maxValues += $" {pair.Key}";
                }
            }

            Console.WriteLine($"{minValues} : {min}");
            Console.WriteLine($"{maxValues} : {max}");
     
}
    }
}
