using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunProblems
{
    public class TripletsProblem
    {
        int a = 1;
        int b = 2;
        int c = 3;
        int attempts = 0;

        public TripletsProblem()
        {
            for(int i = 0; i < 10; i++)
            {
                FindTriplet();
                PrintTriplet();
            }

            Console.ReadKey();
        }

        void FindTriplet()
        {
            for (int i = 1; i < 100; i++)
            {
                a = i;

                for (int j = 2; j < (i^2); j++)
                {
                    b = j;

                    double squareRoot = Math.Sqrt(b*b + a*a);

                    // Seeing if the square root is a whole number
                    if (squareRoot % 1 == 0)
                    {
                        c = (int)squareRoot;
                    }

                    attempts++;

                    if (IsTriplet()) return;
                }
            }
        }

        //int FindB()
        //{
        //    int differenceSquare = c ^ 2 - a ^ 2;

        //    double squareRoot = Math.Sqrt(differenceSquare);

        //    // This is a whole number and a perfect square which means it is B
        //    if (squareRoot % 1 == 0)
        //    {
        //        return (int)squareRoot;
        //    }

        //    // This is not a whole number, keep going
        //    return 0;
        //}

        bool IsTriplet()
        {
            return ((a ^ 2 + b ^ 2) == (c ^ 2));
        }
        
        void PrintTriplet()
        {
            Console.WriteLine($"{a},{b},{c} => {a ^ 2} + {b ^ 2} = {c ^ 2} @ Iteration# {attempts}");
        }
    }
}
