using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            Console.Write("first number * second * third are with sign: ");
            if (firstNumber > 0)
            {
                if (secondNumber > 0)
                {
                    if (thirdNumber > 0)
                    {
                        Console.WriteLine("+");
                    }
                }
                else if (thirdNumber > 0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine("+");
                }
            }
            else if (secondNumber > 0)
            {
                if (thirdNumber > 0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine("+");
                }
            }
            else if (thirdNumber > 0)
            {
                Console.WriteLine("+");
            }
            else
            {
                Console.WriteLine("-");
            }
        }
    }
}
