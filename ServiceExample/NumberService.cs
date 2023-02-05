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
            float num1;
            float num2;

            try
            {
                num1 = float.Parse(stringNum1);
            }
            catch
            {
                return "The first input is not a number, please try again.";
            }

            try
            {
                num2 = float.Parse(stringNum2);
            }
            catch
            {
                return "The second input is not a number, please try again.";
            }

            float numSum = num1 + num2;
            float numDiff = num1 - num2;
            float numProd = num1 * num2;
            float numFrac = num1 / num2;

            return $"The sum of those two numbers is: {numSum}\n" +
                $"The difference between those two numbers is: {numDiff}\n" +
                $"The product of those two numbers is: {numProd}\n" +
                $"The difference between those two numbers is: {numFrac}";
        }
    }
}
