using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.TheBiggestOF3Nums
{
    class TheBiggestOF3Nums
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            if (firstNumber > secondNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    Console.WriteLine(firstNumber);
                }
                else
                {
                    Console.WriteLine(thirdNumber);
                }
            }
            else if (secondNumber > thirdNumber)
            {
                Console.WriteLine(secondNumber);
            }
            else
            {
                Console.WriteLine(thirdNumber);
            }
        }
    }
}
