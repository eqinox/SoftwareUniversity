using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DivideBy7And5
{
    class DivideBy7And5
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool isDivide;
            if (num != 0)
            {
                isDivide = num % 7 == 0 && num % 5 == 0 ? isDivide = true : isDivide = false;
            }
            else
            {
                isDivide = false;
            }
            Console.WriteLine(isDivide);
        }
    }
}
