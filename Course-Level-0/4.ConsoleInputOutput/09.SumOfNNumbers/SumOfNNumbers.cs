using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.SumOfNNumbers
{
    class SumOfNNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Write num: ");
            int num = int.Parse(Console.ReadLine());
            double sum = 0;
            Console.WriteLine("Now write {0} numbers", num);
            for (int i = 0; i < num; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());
                sum += currentNum;
            }
            Console.WriteLine(sum);
        }
    }
}
