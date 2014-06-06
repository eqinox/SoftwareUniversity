using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.HexadecimalToDecimal
{
    class HexadecimalToDecimal
    {
        static void Main(string[] args)
        {
            string hexaNum = Console.ReadLine();
            long result = 0;

            for (int i = hexaNum.Length - 1, position = 0; i >= 0; i--, position++)
            {
                switch (hexaNum[i])
                {
                    case 'A': result += 10 * (long)Math.Pow(16, position);
                        break;             
                    case 'B': result += 11 * (long)Math.Pow(16, position);
                        break;             
                    case 'C': result += 12 * (long)Math.Pow(16, position);
                        break;             
                    case 'D': result += 13 * (long)Math.Pow(16, position);
                        break;             
                    case 'E': result += 14 * (long)Math.Pow(16, position);
                        break;             
                    case 'F': result += 15 * (long)Math.Pow(16, position);
                        break;
                    default: result += int.Parse(hexaNum[i].ToString()) * (long)Math.Pow(16, position);
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
