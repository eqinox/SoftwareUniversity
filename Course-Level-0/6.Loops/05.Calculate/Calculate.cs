using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Calculate
{
    class Calculate
    {
        static void Main(string[] args)
        {
            decimal num = decimal.Parse(Console.ReadLine());
            decimal x = decimal.Parse(Console.ReadLine());

            decimal sum = 1;
            for (decimal i = 1; i <= num; i++)
            {
                decimal currentFactorial = 1;
                for (decimal j = 1; j <= i; j++)
                {
                    currentFactorial *= j;
                }
                sum += currentFactorial / powerN(x, i);
            }
            Console.WriteLine(sum);


        }

        static decimal powerN(decimal num, decimal stepen)
        {
            decimal sum = num;
            for (int i = 1; i < stepen; i++)
            {
                sum *= num;
            }
            return sum;
        }
    }
}
