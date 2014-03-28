using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SumOf5Numbers
{
    class SumOf5Numbers
    {
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 0; i < 5; i++)
            {
                double num = double.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
