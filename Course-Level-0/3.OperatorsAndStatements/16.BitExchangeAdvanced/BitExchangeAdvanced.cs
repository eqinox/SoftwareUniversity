using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.BitExchangeAdvanced
{
    class BitExchangeAdvanced
    {
        static void Main(string[] args)
        {
            uint num = 2369124121;
            int firstBitStartPos = 2;
            int secondBitStartPos = 22;
            int bitsToExchange = 10;
            Dictionary<int, int> bits = new Dictionary<int, int>();
            for (int i = 0; i < bitsToExchange; i++)
            {
                int firstBit = (int)((1 << firstBitStartPos) & num) >> firstBitStartPos;
                int secondBit = (int)((1 << secondBitStartPos) & num) >> secondBitStartPos;
                bits.Add(firstBitStartPos, secondBit);
                bits.Add(secondBitStartPos, firstBit);
                firstBitStartPos++;
                secondBitStartPos++;
            }
            uint numAndMask = num;
            foreach (var item in bits)
            {
                if (item.Value == 1)
                {
                    int mask = 1 << item.Key;
                    numAndMask = (uint)(mask | numAndMask);
                }
                else if (item.Value == 0)
                {
                    int mask = 1 << item.Key;
                    numAndMask = (uint)(~mask & numAndMask);
                }
            }
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(32, '0'));
            Console.WriteLine(Convert.ToString(numAndMask, 2).PadLeft(32, '0'));
            Console.WriteLine("Changed {0} bits from start position {1}, to bits from start position {2}", bitsToExchange, firstBitStartPos, secondBitStartPos);
        }
    }
}
