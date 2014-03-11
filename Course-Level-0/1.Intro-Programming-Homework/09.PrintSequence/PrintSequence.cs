using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...*/
namespace _09.PrintSequence
{
    class PrintSequence
    {
        static void Main(string[] args)
        {
            int first = 2;
            int second = -3;
            for (int i = 0; i < 5; i++)
            {
                Console.Write(first + ", ");
                Console.Write(second + ", ");
                first+=2;
                second-=2;
            }
        }
    }
}
