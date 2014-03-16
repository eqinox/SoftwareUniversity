using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ExtractBit3
{
    class ExtractBit3
    {
        static void Main(string[] args)
        {
            int a = 18;
            Console.WriteLine(Convert.ToString(a, 2).PadLeft(32, '0'));
            int bitPosition = 2;
            int mask = 1 << bitPosition;
            int numAndMask = mask & a;
            int bit = numAndMask >> bitPosition;
            bool is3One = bit == 1? is3One = true : is3One = false;
            Console.WriteLine("is third bit 1?: " + is3One);
        }
    }
}
