using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            string result = "";

            while (num > 0)
            {
                result += num % 2;
                num /= 2;
            }

            string reversedResult = "";
            for (int i = result.Length - 1; i >= 0; i--)
            {
                reversedResult += result[i];
            }

            Console.WriteLine(reversedResult);
        }
    }
}
