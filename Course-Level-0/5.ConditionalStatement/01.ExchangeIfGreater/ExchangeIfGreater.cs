using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ExchangeIfGreater
{
    class ExchangeIfGreater
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            if (first > second)
            {
                double third = second;
                second = first;
                first = third;
            }

            Console.WriteLine("{0} {1}", first, second);
        }
    }
}
