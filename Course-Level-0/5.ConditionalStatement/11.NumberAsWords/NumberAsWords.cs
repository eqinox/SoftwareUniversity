using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.NumberAsWords
{
    class NumberAsWords
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int numberAsInt = int.Parse(number);
            int firstDigit = new int();
            int secondDigit = new int();
            if (numberAsInt > 10)
            {
                firstDigit = int.Parse(number[0].ToString());
                secondDigit = int.Parse(number[1].ToString());
            }

            if (numberAsInt <= 20)
            {
                switch (numberAsInt)
                {
                    case 0: Console.Write("Zero");
                        break;
                    case 1: Console.Write("One");
                        break;
                    case 2: Console.Write("Two");
                        break;
                    case 3: Console.Write("Tree");
                        break;
                    case 4: Console.Write("Four");
                        break;
                    case 5: Console.Write("Five");
                        break;
                    case 6: Console.Write("Six");
                        break;
                    case 7: Console.Write("Seven");
                        break;
                    case 8: Console.Write("Eight");
                        break;
                    case 9: Console.Write("Nine");
                        break;
                    case 10: Console.Write("Ten");
                        break;
                    case 11: Console.Write("Eleven");
                        break;
                    case 12: Console.Write("Twelve");
                        break;
                    case 13: Console.Write("Thirteen");
                        break;
                    case 14: Console.Write("Fourteen");
                        break;
                    case 15: Console.Write("Fiveteen");
                        break;
                    case 16: Console.Write("Sixteen");
                        break;
                    case 17: Console.Write("Seventeen");
                        break;
                    case 18: Console.Write("Eighteen");
                        break;
                    case 19: Console.Write("Nineteen");
                        break;
                    case 20: Console.Write("twenty");
                        break;
                    default: Console.WriteLine("Error");
                        break;
                }
                Console.WriteLine();
            }
            else if (numberAsInt > 20 && numberAsInt < 100)
            {
                switch (firstDigit)
                {
                    case 2: Console.Write("twenty-");
                        break;
                    case 3: Console.Write("thirty-");
                        break;
                    case 4: Console.Write("fourthy-");
                        break;
                    case 5: Console.Write("fifty-");
                        break;
                    case 6: Console.Write("sixty-");
                        break;
                    case 7: Console.Write("seventy-");
                        break;
                    case 8: Console.Write("eighty-");
                        break;
                    case 9: Console.Write("ninety-");
                        break;
                    default: Console.Write("error at between 20 and 100");
                        break;
                }
                switch (secondDigit)
                {
                    case 1: Console.Write("One");
                        break;
                    case 2: Console.Write("Two");
                        break;
                    case 3: Console.Write("Tree");
                        break;
                    case 4: Console.Write("Four");
                        break;
                    case 5: Console.Write("Five");
                        break;
                    case 6: Console.Write("Six");
                        break;
                    case 7: Console.Write("Seven");
                        break;
                    case 8: Console.Write("Eight");
                        break;
                    case 9: Console.Write("Nine");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
            else if ((numberAsInt >= 100 && numberAsInt < 120) || (numberAsInt >= 200 && numberAsInt < 220) || (numberAsInt >= 300 && numberAsInt < 320) ||
                (numberAsInt >= 400 && numberAsInt < 420) || (numberAsInt >= 500 && numberAsInt < 520) || (numberAsInt >= 600 && numberAsInt < 620) ||
                (numberAsInt >= 700 && numberAsInt < 720) || (numberAsInt >= 800 && numberAsInt < 820) || (numberAsInt >= 900 && numberAsInt < 920))
            {
                switch (firstDigit)
                {
                    case 1: Console.Write("One Hundred ");
                        break;
                    case 2: Console.Write("Two Hundred ");
                        break;
                    case 3: Console.Write("Tree Hundred ");
                        break;
                    case 4: Console.Write("Fourth Hundred ");
                        break;
                    case 5: Console.Write("Five Hundred ");
                        break;
                    case 6: Console.Write("Six Hundred ");
                        break;
                    case 7: Console.Write("Seven Hundred ");
                        break;
                    case 8: Console.Write("Eight Hundred ");
                        break;
                    case 9: Console.Write("Nine Hundred ");
                        break;
                    default: Console.WriteLine("error at firstDigit");
                        break;
                }
                switch (numberAsInt % 100)
                {
                    case 1: Console.Write("And One");
                        break;
                    case 2: Console.Write("And Two");
                        break;
                    case 3: Console.Write("And Tree");
                        break;
                    case 4: Console.Write("And Four");
                        break;
                    case 5: Console.Write("And Five");
                        break;
                    case 6: Console.Write("And Six");
                        break;
                    case 7: Console.Write("And Seven");
                        break;
                    case 8: Console.Write("And Eight");
                        break;
                    case 9: Console.Write("And Nine");
                        break;
                    case 10: Console.Write("And Ten");
                        break;
                    case 11: Console.Write("And Eleven");
                        break;
                    case 12: Console.Write("And Twelve");
                        break;
                    case 13: Console.Write("And Thirteen");
                        break;
                    case 14: Console.Write("And Fourteen");
                        break;
                    case 15: Console.Write("And Fiveteen");
                        break;
                    case 16: Console.Write("And Sixteen");
                        break;
                    case 17: Console.Write("And Seventeen");
                        break;
                    case 18: Console.Write("And Eighteen");
                        break;
                    case 19: Console.Write("And Nineteen");
                        break;
                    case 20: Console.Write("And twenty");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
            else
            {
                switch (firstDigit)
                {
                    case 1: Console.Write("One Hundred ");
                        break;
                    case 2: Console.Write("Two Hundred ");
                        break;
                    case 3: Console.Write("Tree Hundred ");
                        break;
                    case 4: Console.Write("Fourth Hundred ");
                        break;
                    case 5: Console.Write("Five Hundred ");
                        break;
                    case 6: Console.Write("Six Hundred ");
                        break;
                    case 7: Console.Write("Seven Hundred ");
                        break;
                    case 8: Console.Write("Eight Hundred ");
                        break;
                    case 9: Console.Write("Nine Hundred ");
                        break;
                    default: Console.WriteLine("error at firstDigit");
                        break;
                }
                switch (secondDigit)
                {
                    case 1: Console.Write("");
                        break;
                    case 2: Console.Write(" and twenty");
                        break;
                    case 3: Console.Write(" and thirty");
                        break;
                    case 4: Console.Write(" and forty");
                        break;
                    case 5: Console.Write(" and fifty");
                        break;
                    case 6: Console.Write(" and sixty");
                        break;
                    case 7: Console.Write(" and seventy");
                        break;
                    case 8: Console.Write(" and eighty");
                        break;
                    case 9: Console.Write(" and ninety");
                        break;
                    default: Console.WriteLine("error");
                        break;
                }
                switch (numberAsInt % 10)
                {
                    case 1: Console.Write("-One");
                        break;
                    case 2: Console.Write("-Two");
                        break;
                    case 3: Console.Write("-Tree");
                        break;
                    case 4: Console.Write("-Four");
                        break;
                    case 5: Console.Write("-Five");
                        break;
                    case 6: Console.Write("-Six");
                        break;
                    case 7: Console.Write("-Seven");
                        break;
                    case 8: Console.Write("-Eight");
                        break;
                    case 9: Console.Write("-Nine");
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
