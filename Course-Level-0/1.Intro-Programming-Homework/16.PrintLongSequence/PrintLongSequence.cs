using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, … 
 * You might need to learn how to use loops in C# (search in Internet).
 * */

namespace _16.PrintLongSequence
{
    class PrintLongSequence
    {
        static void Main(string[] args)
        {
            int first = 2;
            int second = -3;
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(first + ", ");
                Console.Write(second + ", ");
                first += 2;
                second -= 2;
            }
        }
    }
}
