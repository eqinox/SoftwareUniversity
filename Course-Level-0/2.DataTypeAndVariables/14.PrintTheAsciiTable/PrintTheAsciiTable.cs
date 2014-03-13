using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.PrintTheAsciiTable
{
    class PrintTheAsciiTable
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int c = 1;
            for (int i = 0; i < 255; i++)
            {
                Console.Write((char)c + " ");
                c++;
            }
        }
    }
}
