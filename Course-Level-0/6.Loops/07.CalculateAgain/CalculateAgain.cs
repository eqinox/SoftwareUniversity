using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CalculateAgain
{
    class CalculateAgain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int nMinusK = n - k;
            long nFactorial = 1;
            long nMinusKFactorial = 1;

            long kFactorial = 1;

            for (int i = 1; i <= n; i++)
            {
                if (i <= k)
                {
                    kFactorial *= i;
                }
                nFactorial *= i;
            }

            for (int i = 1; i <= nMinusK; i++)
            {
                nMinusKFactorial *= i;
            }
            Console.WriteLine(nFactorial / (kFactorial * nMinusKFactorial));


        }
    }
}
