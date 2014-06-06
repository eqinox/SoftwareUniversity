using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.OddAndEvenProduct
{
    class OddAndEvenProduct
    {
        static void Main(string[] args)
        {
            string[] numsAsStr = Console.ReadLine().Split();
            int oddProduct = 1;
            int evenProduct = 1;
            for (int i = 0; i < numsAsStr.Length; i++)
            {
                int num = int.Parse(numsAsStr[i]);
                if (i % 2 == 0)
                {
                    oddProduct *= num;
                }
                else
                {
                    evenProduct *= num;
                }
            }

            if (evenProduct == oddProduct)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Product: {0}", evenProduct);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Even Product: {0}", evenProduct);
                Console.WriteLine("Odd Product: {0}", oddProduct);
            }
            

        }
    }
}
