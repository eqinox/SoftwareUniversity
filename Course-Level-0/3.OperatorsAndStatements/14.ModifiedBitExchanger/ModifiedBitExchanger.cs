using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ModifiedBitExchanger
{
    class ModifiedBitExchanger
    {
        static void Main(string[] args)
        {
            int num = 5543;
            int bitPosition = 2;
            int bitToExchange = 0;
            int numAndMask = 0;
            if (bitToExchange == 1)
            {
                int mask = 1 << bitPosition;
                numAndMask = mask | num;
            }
            else if (bitToExchange == 0)
            {
                int mask = 1 << bitPosition;
                numAndMask = ~mask & num;
            }
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(numAndMask, 2).PadLeft(32, '0'));
            Console.WriteLine("Exchanged bit {0} with {1}", bitPosition, bitToExchange);
        }
    }
}
