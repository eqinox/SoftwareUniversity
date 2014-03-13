using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.IsoscelesTriangle
{
    class IsoscelesTriangle
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            char symbol = '\u00a9';
            int leftSpaces = 3;
            int middleSpaces = 0;
            Console.WriteLine(new string(' ', leftSpaces) + symbol + new string(' ', leftSpaces));
            leftSpaces--;
            middleSpaces=1;
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(new string(' ', leftSpaces) + symbol +
                    new string(' ', middleSpaces) + symbol + new string(' ', leftSpaces));
                leftSpaces--;
                middleSpaces += 2;
            }
            for (int i = 0; i < 7; i++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write(symbol);
                }
            }
            Console.WriteLine();
        }
    }
}
