using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.BitExchange
{
    class BitExchange
    {
        static void Main(string[] args)
        {
            int num = 1140867093;
            int bit3 = ((1 << 3) & num) >> 3;
            int bit4 = ((1 << 4) & num) >> 4;
            int bit5 = ((1 << 5) & num) >> 5;
            
            int bit24 = ((1 << 24) & num) >> 24;
            int bit25 = ((1 << 25) & num) >> 25;
            int bit26 = ((1 << 26) & num) >> 26;

            int[] bits = new int[] { bit3, bit4, bit5, bit24, bit25, bit26 };
            Dictionary<int, int> bitss = new Dictionary<int, int>();
            string numAsStr = Convert.ToString(num, 2).PadLeft(32, '0');

            bitss.Add(3, bit24);
            bitss.Add(4, bit25);
            bitss.Add(5, bit26);
            bitss.Add(24, bit3);
            bitss.Add(25, bit4);
            bitss.Add(26, bit5);
            int numAndMask = num;
            foreach (var item in bitss)
            {
                if (item.Value == 1)
                {
                    int mask = 1 << item.Key;
                    numAndMask = mask | numAndMask;
                }
                else if (item.Value == 0)
                {
                    int mask = 1 << item.Key;
                    numAndMask = ~mask & numAndMask;
                }
            }

            for (int i = 0; i < numAsStr.Length; i++)
            {
                if (i == 5 || i == 6 || i == 7 || i == 28 || i == 27 || i == 26)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                }
                Console.Write(numAsStr[i]);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
            Console.WriteLine(Convert.ToString(numAndMask, 2).PadLeft(32, '0'));
        }
    }
}
