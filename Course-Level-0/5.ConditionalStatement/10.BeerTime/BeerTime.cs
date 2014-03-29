using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.BeerTime
{
    class BeerTime
    {
        static void Main(string[] args)
        {
            Console.WriteLine("format: HH:MM:TT (1-12:0-59:AM/PM)");
            Console.WriteLine("Example: 09:31:31 PM");
            while (true)
            {
                StringBuilder input = new StringBuilder(Console.ReadLine());
                DateTime time = DateTime.Parse(input.ToString());
                string top = "3:00:00 PM";
                string bottom = "1:00:00 AM";
                DateTime topTime = DateTime.Parse(top);
                DateTime bottomTime = DateTime.Parse(bottom);
                if (time >= topTime && time <= bottomTime)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("non-beer time");
                }
            }
        }
    }
}
