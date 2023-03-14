using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UnitTestDemo
{
    public class Utilities
    {
        public static double GetFloorForDouble(double input)
        {
            return Math.Floor(input);
        }

        public static string NameJoiner(string firstname, string lastname)
        {
            return $"{firstname}, {lastname}";
        }

        public static string StringHasher(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static bool IsPrime(int input)
        {
            if (input == 1 || input == 0) return false;

            if (input == 2) return true;

            if (input % 2 == 0) return false;

            for(int i = 2; i < input/2; i++)
            {
                if (input % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static List<int> GetAllNonPrimeDivisors(int input)
        {
            List<int> divisors = new List<int>();

            if (input == 0) return divisors;

            for(int i = 1; i < input+1; i++)
            {
                if (!IsPrime(i) && input % i == 0)
                {
                    divisors.Add(i);
                }
            }

            return divisors;
        }

        public static double GetFloorOfFraction(int num1, int num2)
        {
            double numerator;
            double denominator;

            if (num1 > num2)
            {
                numerator = num1;
                denominator = num2;
            } else
            {
                numerator = num2;
                denominator = num1;
            }

            return GetFloorForDouble(numerator / denominator);
        }

        public static Dictionary<int, int> MakeOddDictionary(int input)
        {
            Dictionary<int, int> oddDictionary = new Dictionary<int, int>();
            List<int> nums = GetAllNonPrimeDivisors(input);
            int currentKey = 1;

            foreach(int num in nums)
            {
                oddDictionary.Add(currentKey, num);
                currentKey += 2;
            }


            return oddDictionary;
        }
    }
}
