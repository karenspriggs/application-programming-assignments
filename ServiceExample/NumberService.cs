using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExample
{
    internal class NumberService
    {
        public string ReturnResults(float num1, float num2)
        {
            if (float.IsNaN(num1) || float.IsNaN(num2))
            {
                return "Please enter two numbers";
            }

            float numSum = num1 + num2;
            float numDiff = num1 - num2;
            float numProd = num1 * num2;
            float numFrac = num1 / num2;

            return $"The sum of those two numbers is: {numSum}" +
                $"The difference between those two numbers is: {numDiff}" +
                $"The product of those two numbers is: {numProd}" +
                $"The difference between those two numbers is: {numFrac}";
        }
    }
}
