using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11.RandumNumbersInGivenRange
{
    class RandumNumbersInGivenRange
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums; i++)
            {
                Random randomNumber = new Random();
                int num = randomNumber.Next(min, max + 1);
                Thread.Sleep(10);
                Console.Write("{0} ", num);
            }
        }
    }
}
