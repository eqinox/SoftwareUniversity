using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ComparingFloats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            decimal first = -0.000001m;
            decimal second = 0.000006m;
            StringBuilder firstStr = new StringBuilder();
            StringBuilder secondStr = new StringBuilder();
            if ((int)first == 0)
            {
                firstStr.Append(Math.Abs(first));
            }
            else
            {
                firstStr.Append(first);
            }
            if ((int)second == 0)
            {
                secondStr.Append(Math.Abs(second));
            }
            else
            {
                secondStr.Append(second);
            }
            firstStr.Length = 8;
            secondStr.Length = 8;
            string a = firstStr.ToString();
            string b = secondStr.ToString();
            Console.WriteLine(a == b);
        }
    }
}
