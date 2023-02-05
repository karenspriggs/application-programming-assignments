using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExample
{
    internal class NumberService
    {
        public string ReturnResults(string stringNum1, string stringNum2)
        {
            double num1;
            double num2;

            try
            {
                num1 = Double.Parse(stringNum1);
            }
            catch
            {
                return "The first input is not a number, please try again.";
            }

            try
            {
                num2 = Double.Parse(stringNum2);
            }
            catch
            {
                return "The second input is not a number, please try again.";
            }

            double numSum = num1 + num2;
            double numDiff = num1 - num2;
            double numProd = num1 * num2;
            double numFrac = num1 / num2;

            return $"The sum of those two numbers is: {numSum}\n" +
                $"The difference between those two numbers is: {numDiff}\n" +
                $"The product of those two numbers is: {numProd}\n" +
                $"The difference between those two numbers is: {numFrac}";
        }
    }
}
