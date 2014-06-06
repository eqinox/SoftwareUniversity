using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.N_DividedK_
{
    class NDividedK
    {
        static void Main(string[] args)
        {
            Console.Write("Write N: ");
            int numberForN = int.Parse(Console.ReadLine());
            Console.Write("Write K: ");
            int numberForK = int.Parse(Console.ReadLine());
            long nFactorial = 1;
            long kFactorial = 1;
            for (int i = 1; i <= numberForN; i++)
            {
                nFactorial = nFactorial * i;
            }
            for (int i = 1; i <= numberForK; i++)
            {
                kFactorial *= i;
            }
            Console.WriteLine("N! / K! = {0}", nFactorial / kFactorial);
        }
    }
}
