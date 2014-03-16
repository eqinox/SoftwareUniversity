using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddOrEven
{
    class OddOrEven
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool odd = num % 2 == 0 ? odd = false : odd = true;
            Console.WriteLine(odd);
        }
    }
}
