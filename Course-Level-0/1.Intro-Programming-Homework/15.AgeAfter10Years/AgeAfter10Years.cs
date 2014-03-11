using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Write a program to read your birthday from the console and print
 * how old you are now and how old you will be after 10 years.*/
namespace _15.AgeAfter10Years
{
    class AgeAfter10Years
    {
        static void Main(string[] args)
        {
            Console.Write("Your ages now: ");
            int ages = int.Parse(Console.ReadLine());
            Console.WriteLine("Your ages after 10 years: {0}", ages + 10);
        }
    }
}
