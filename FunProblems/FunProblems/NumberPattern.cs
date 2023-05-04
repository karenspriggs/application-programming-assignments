using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunProblems
{
    public class NumberPattern
    {
        public NumberPattern(int number)
        {
            PrintSequence(number);
        }

        void PrintSequence(int number)
        {
            int currentstep = 0;

            while (currentstep < number)
            {
                PrintStep(number, currentstep);
                Console.WriteLine("");
                currentstep++;
            }

            Console.ReadKey();
        }

        void PrintStep(int maxnum, int stepnum)
        {
            int startingnum = maxnum - stepnum;
            int currentnum = startingnum;

            while (currentnum < maxnum)
            {
                Console.Write($"{currentnum}" );
                currentnum++;
            }

            if (currentnum == maxnum)
            {
                Console.Write(maxnum);
            }

            while (currentnum > startingnum)
            {
                currentnum--;
                Console.Write($"{currentnum}");
            }
        }
    }
}
