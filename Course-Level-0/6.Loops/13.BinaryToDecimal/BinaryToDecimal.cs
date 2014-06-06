using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main(string[] args)
        {
            string binary = Console.ReadLine();
            long number = 0;
            for (int i = binary.Length - 1, secondPos = 0; i >= 0; i--, secondPos++)
            {
                number += int.Parse(binary[i].ToString()) * (long)Math.Pow(2, secondPos);
            }
            Console.WriteLine(number);
        }
    }
}
