using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FourDigitNumber
{
    class FourDigitNumber
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int a = int.Parse(input[0].ToString());
            int b = int.Parse(input[1].ToString());
            int c = int.Parse(input[2].ToString());
            int d = int.Parse(input[3].ToString());
            int firstTask = a + b + c + d;
            string secondTask = d.ToString() + c + b + a;
            string thirdTask = d.ToString() + a + b + c;
            string fourthTask = a.ToString() + c + b + d;
            Console.WriteLine(firstTask);
            Console.WriteLine(secondTask);
            Console.WriteLine(thirdTask);
            Console.WriteLine(fourthTask);

        }
    }
}
