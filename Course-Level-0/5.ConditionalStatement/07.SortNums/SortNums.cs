using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SortNums
{
    class SortNums
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            if (first > second)
            {
                if (first > third)
                {
                    if (second > third)
                    {
                        Console.WriteLine("{0}{1}{2}", first, second, third);
                    }
                    else
                    {
                        Console.WriteLine("{0}{1}{2}", first, third, second);
                    }
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}", third, first, second);
                }
            }
            else if (second > third)
            {
                if (first > third)
                {
                    Console.WriteLine("{0}{1}{2}", second, first, third);
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}", second, third, first);
                }
            }
            else
            {
                if (first > second)
                {
                    Console.WriteLine("{0}{1}{2}", third, first, second);
                }
                else
                {
                    Console.WriteLine("{0}{1}{2}", third, second, first);
                }
            }
        }
    }
}
