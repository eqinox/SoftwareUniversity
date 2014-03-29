using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PlayWithIntDoubleOrString
{
    class PlayWithIntDoubleOrString
    {
        static void Main(string[] args)
        {
            dynamic jsutVariable = Console.ReadLine();
            int isInt;
            double isDouble;
            if (int.TryParse(jsutVariable, out isInt))
            {
                Console.WriteLine(isInt + 1);
            }
            else if (double.TryParse(jsutVariable, out isDouble))
            {
                Console.WriteLine(isDouble + 1);
            }
            else
            {
                Console.WriteLine(jsutVariable + "*");
            }
        }
    }
}
