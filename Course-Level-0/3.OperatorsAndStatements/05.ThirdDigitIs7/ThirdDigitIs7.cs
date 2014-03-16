using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ThirdDigitIs7
{
    class ThirdDigitIs7
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                num /= 10;
            }
            bool is7 = num % 10 == 7 ? is7 = true : is7 = false;
            Console.WriteLine(is7);
        }
    }
}
