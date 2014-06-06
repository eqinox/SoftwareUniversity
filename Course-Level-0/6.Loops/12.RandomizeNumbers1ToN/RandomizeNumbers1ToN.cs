using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.RandomizeNumbers1ToN
{
    class RandomizeNumbers1ToN
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();

            for (int i = 1; i <= num; i++)
            {
                nums.Add(i);
            }

            while (nums.Count != 0)
            {
                int position = new Random().Next(0, nums.Count);
                Console.Write(nums[position] + " ");
                nums.RemoveAt(position);
            }
        }
    }
}
