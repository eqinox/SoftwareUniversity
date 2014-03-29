using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.ZeroSubset
{
    class ZeroSubset
    {
        static void Main(string[] args)
        {
            int[] nums = new int[5];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            int maxCycle = (int)Math.Pow(2, nums.Length) - 1;
            List<int> numsUsed = new List<int>();
            for (int i = 1; i <= maxCycle; i++)
            {
                int currentSum = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    int mask = 1 << j;
                    int bit = (mask & i) >> j;
                    if (bit == 1)
                    {
                        currentSum += nums[j];
                        numsUsed.Add(nums[j]);
                    }
                }
                if (currentSum == 0)
                {
                    string textToDisplay = string.Join(" + ", numsUsed);
                    textToDisplay += " = 0";
                    Console.WriteLine(textToDisplay);
                }
                numsUsed.Clear();
            }
        }
    }
}
