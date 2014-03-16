using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ExtractBitFromInteger
{
    class ExtractBitFromInteger
    {
        static void Main(string[] args)
        {
            int a = 5343;
            Console.WriteLine(Convert.ToString(a, 2).PadLeft(32, '0'));
            int bitPosition = 7;
            int mask = 1 << bitPosition;
            int numAndMask = mask & a;
            int bit = numAndMask >> bitPosition;
            Console.WriteLine("bit at position {0} is {1}", bitPosition, bit);
        }
    }
}
