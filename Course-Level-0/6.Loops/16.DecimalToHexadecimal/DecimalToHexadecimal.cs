using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.DecimalToHexadecimal
{
    class DecimalToHexadecimal
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            string result = "";

            while (num > 0)
            {
                long symbol = num % 16;
                switch (symbol)
                {
                    case 10: result += "A";
                        break;
                    case 11: result += "B";
                        break;
                    case 12: result += "C";
                        break;
                    case 13: result += "D";
                        break;
                    case 14: result += "E";
                        break;
                    case 15: result += "F";
                        break;
                    default: result += symbol;
                        break;
                }
                num /= 16;
            }
            string newResult = "";
            for (int i = result.Length - 1; i >= 0; i--)
            {
                newResult += result[i];
            }
            Console.WriteLine(newResult);
        }
    }
}
