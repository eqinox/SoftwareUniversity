using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum3Numbers
{
    class Sum3Numbers
    {
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                double num = double.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
