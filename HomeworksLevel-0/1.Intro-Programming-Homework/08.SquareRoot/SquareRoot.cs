using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Create a console application that calculates and prints the square root
 * of the number 12345. Find in Internet “how to calculate square root in C#”.*/
namespace _08.SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Sqrt(26));
        }

        static double CalculateSqrt(double num)
        {
            double n = 1;
            double sum = 1;
            while (sum != num)
            {
                sum = n * n;
                if (sum > num)
                {
                    n -= 0.1;
                }
                else if (sum < num)
                {
                    n++;
                }
            }
            return n;
        }
    }
}
