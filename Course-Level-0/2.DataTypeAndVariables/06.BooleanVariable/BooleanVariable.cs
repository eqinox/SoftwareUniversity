using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BooleanVariable
{
    class BooleanVariable
    {
        static void Main(string[] args)
        {
            string name = "iliqna";
            bool isFemale = false;
            if (name[name.Length - 1] == 'a' || name[name.Length - 1] == 'q' || name[name.Length - 1] == 'i')
            {
                isFemale = true;
            }

            if (isFemale)
            {
                Console.WriteLine("you are female");
            }
            else
            {
                Console.WriteLine("you are male");
            }
        }
    }
}
