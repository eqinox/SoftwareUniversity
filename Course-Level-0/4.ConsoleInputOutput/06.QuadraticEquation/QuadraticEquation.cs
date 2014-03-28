using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main(string[] args)
        {
            Console.Write("a=");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b=");
            int b = int.Parse(Console.ReadLine());
            Console.Write("c=");
            int c = int.Parse(Console.ReadLine());
            int D = b * b - 4 * a * c;
            Console.WriteLine("D = {0}", D);
            if (D > 0)
            {
                Console.WriteLine("x1 = {0}", (int)(-b + Math.Sqrt(D)) / 2);
                Console.WriteLine("x2 = {0}", (int)(-b - Math.Sqrt(D)) / 2);
            }
            else
            {
                Console.WriteLine("quadratic equation haven't real roots");
            }
        }
    }
}
