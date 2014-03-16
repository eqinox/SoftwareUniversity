using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.PrimeNumberCheck
{
    class PrimeNumberCheck
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int maxCount = (int)(Math.Sqrt(num));
            bool isPrime = true;
            if (num <= 0)
            {
                isPrime = false;
                maxCount = 0;
            }
            for (int i = 2; i <= maxCount; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine(isPrime);
        }
    }
}
