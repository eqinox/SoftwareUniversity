using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            float second = float.Parse(Console.ReadLine());
            float third = float.Parse(Console.ReadLine());

            Console.WriteLine("|{0,-10:X}|{1}|{2,10:f2}|{3,-10:0.000}|", first, (Convert.ToString(first, 2).PadLeft(10, '0')), second, third);
        }
    }
}
