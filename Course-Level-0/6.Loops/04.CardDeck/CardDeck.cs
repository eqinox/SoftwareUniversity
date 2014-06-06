using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CardDeck
{
    class CardDeck
    {
        static void Main(string[] args)
        {
            char spade = '\u2660';
            char club = '\u2663';
            char heart = '\u2665';
            char diamond = '\u2666';
            for (int i = 1; i <= 14; i++)
            {
                switch (i)
                {
                    case 1: Console.Write("1{0}   ", spade); Console.Write("1{0}   ", club); Console.Write("1{0}   ", heart); Console.Write("1{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 2: Console.Write("2{0}   ", spade); Console.Write("2{0}   ", club); Console.Write("2{0}   ", heart); Console.Write("2{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 3: Console.Write("3{0}   ", spade); Console.Write("3{0}   ", club); Console.Write("3{0}   ", heart); Console.Write("3{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 4: Console.Write("4{0}   ", spade); Console.Write("4{0}   ", club); Console.Write("4{0}   ", heart); Console.Write("4{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 5: Console.Write("5{0}   ", spade); Console.Write("5{0}   ", club); Console.Write("5{0}   ", heart); Console.Write("5{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 6: Console.Write("6{0}   ", spade); Console.Write("6{0}   ", club); Console.Write("6{0}   ", heart); Console.Write("6{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 7: Console.Write("7{0}   ", spade); Console.Write("7{0}   ", club); Console.Write("7{0}   ", heart); Console.Write("7{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 8: Console.Write("8{0}   ", spade); Console.Write("8{0}   ", club); Console.Write("8{0}   ", heart); Console.Write("8{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 9: Console.Write("9{0}   ", spade); Console.Write("9{0}   ", club); Console.Write("9{0}   ", heart); Console.Write("9{0}   ", diamond);
                        Console.WriteLine();
                        break;
                    case 10: Console.Write("{0}{1}", "10", spade); Console.Write("{0,10}{1}", "10", club); Console.Write("{0,10}{1}", "10", heart); Console.Write("{0,10}{1}", "10", diamond);
                        Console.WriteLine();
                        break;
                    case 11: Console.Write("{0}{1}", "Jack", spade); Console.Write("{0,10}{1}", "Jack", club); Console.Write("{0,10}{1}", "Jack", heart); Console.Write("{0,10}{1}", "Jack", diamond);
                        Console.WriteLine();
                        break;
                    case 12: Console.Write("{0}{1}", "Queen", spade); Console.Write("{0,10}{1}", "Queen", club); Console.Write("{0,10}{1}", "Queen", heart); Console.Write("{0,10}{1}", "Queen", diamond);
                        Console.WriteLine();
                        break;
                    case 13: Console.Write("{0}{1}", "King", spade); Console.Write("{0,10}{1}", "King", club); Console.Write("{0,10}{1}", "King", heart); Console.Write("{0,10}{1}", "King", diamond);
                        Console.WriteLine();
                        break;
                    case 14: Console.Write("{0}{1}", "Ace", spade); Console.Write("{0,10}{1}", "Ace", club); Console.Write("{0,10}{1}", "Ace", heart); Console.Write("{0,10}{1}", "Ace", diamond);
                        Console.WriteLine();
                        break;
                    default: Console.WriteLine("Error");
                        break;
                }
            }
        }
    }
}
