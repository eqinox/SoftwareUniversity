using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Fibonacci
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int first = 0;
            int second = 0;
            int third = 1;
            for (int i = 0; i < num; i++)
            {
                first = second + third;
                Console.Write(second + " ");
                third = second;
                second = first;
            }
        }
    }
}
