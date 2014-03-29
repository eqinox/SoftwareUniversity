using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BiggestOf5Nums
{
    class BiggestOf5Nums
    {
        static void Main(string[] args)
        {
            int firstNumber = new int();
            int biggestNumber = new int();
            for (int i = 0; i < 5; i++)
            {
                firstNumber = int.Parse(Console.ReadLine());
                if (firstNumber > biggestNumber)
                {
                    biggestNumber = firstNumber;
                }
            }
            Console.WriteLine(biggestNumber);
        }
    }
}
