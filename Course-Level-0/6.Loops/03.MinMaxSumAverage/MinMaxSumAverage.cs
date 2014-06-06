using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinMaxSumAverage
{
    class MinMaxSumAverage
    {
        static void Main(string[] args)
        {
            int cycle = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;
            double average = 0;

            for (int i = 0; i < cycle; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum > max)
                {
                    max = currentNum;
                }
                if (currentNum < min)
                {
                    min = currentNum;
                }
                sum += currentNum;
            }
            average = sum / cycle;
            Console.WriteLine("Min:{0}", min);
            Console.WriteLine("Max:{0}", max);
            Console.WriteLine("Sum:{0}", sum);
            Console.WriteLine("Average:{0}", average);


        }
    }
}
