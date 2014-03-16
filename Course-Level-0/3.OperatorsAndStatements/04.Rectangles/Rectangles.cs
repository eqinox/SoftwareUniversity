using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Rectangles
{
    class Rectangles
    {
        static void Main(string[] args)
        {
            Console.Write("width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("height: ");
            double height = double.Parse(Console.ReadLine());
            double perimeter = width * 2 + height * 2;
            double area = width * height;
            Console.WriteLine("perimeter: {0}", perimeter);
            Console.WriteLine("area: {0}", area);
        }
    }
}
