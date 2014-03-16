using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GravitationOnTheMoon
{
    class GravitationOnTheMoon
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            double weightOnMoon = (weight / 100) * 17;
            Console.WriteLine("weight on the moon will be: " + weightOnMoon);
        }
    }
}
