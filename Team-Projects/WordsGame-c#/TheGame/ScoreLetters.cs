/* Оценка на думата според честота на срещане в английският език на буквите, които я съставят
 * (според 
 * "What is the frequency of the letters of the alphabet in English?". Oxford Dictionary.
 * Oxford University Press. Retrieved 29 December 2012.)
 * The third column represents proportions, taking the least common letter (q) as equal to 1. 
 * The letter E is over 56 times more common than Q in forming individual English words.
 * http://www.oxforddictionaries.com/words/what-is-the-frequency-of-the-letters-of-the-alphabet-in-english
E	11.1607% 56.88	M	3.0129%	15.36
A	8.4966%	 43.31	H	3.0034%	15.31
R	7.5809%	 38.64	G	2.4705%	12.59
I	7.5448%	 38.45	B	2.0720%	10.56
O	7.1635%	 36.51	F	1.8121%	9.24
T	6.9509%	 35.43	Y	1.7779%	9.06
N	6.6544%	 33.92	W	1.2899%	6.57
S	5.7351%	 29.23	K	1.1016%	5.61
L	5.4893%	 27.98	V	1.0074%	5.13
C	4.5388%	 23.13	X	0.2902%	1.48
U	3.6308%	 18.51	Z	0.2722%	1.39
D	3.3844%	 17.25	J	0.1965%	1.00
P	3.1671%	 16.14	Q	0.1962%	(1)         */
using System;
using System.Diagnostics;
using System.IO;

namespace TheGame
{
    class Score
    {
        const double bonusA = 1;
        const double bonusB = 1.5;
        const double bonusC = 2;
        const double bonusD = 2.5;
        const double bonusE = 3;

        public static int ScoreLetters(string word)
        {
            double scoreLetter = 0;

            foreach (var letter in word)
            {
                // EARIO
                if (letter == 'e' || letter == 'a' || letter == 'r' || letter == 'i' || letter == 'o' ||
                    letter == 'E' || letter == 'A' || letter == 'R' || letter == 'I' || letter == 'O')
                {
                    scoreLetter += bonusA; continue;
                }
                // TNSLC
                if (letter == 't' || letter == 'n' || letter == 's' || letter == 'l' || letter == 'c' ||
                    letter == 'T' || letter == 'N' || letter == 'S' || letter == 'L' || letter == 'C')
                {
                    scoreLetter += bonusB; continue;
                }
                //UDPMH
                if (letter == 'u' || letter == 'd' || letter == 'p' || letter == 'm' || letter == 'h' ||
                    letter == 'U' || letter == 'D' || letter == 'P' || letter == 'M' || letter == 'H')
                {
                    scoreLetter += bonusC; continue;
                }
                //GBFYW
                if (letter == 'g' || letter == 'b' || letter == 'f' || letter == 'y' || letter == 'w' ||
                    letter == 'G' || letter == 'B' || letter == 'F' || letter == 'Y' || letter == 'W')
                {
                    scoreLetter += bonusD; continue;
                }
                //KVXZJQ
                if (letter == 'k' || letter == 'v' || letter == 'x' || letter == 'z' || letter == 'j' || letter == 'q' ||
                    letter == 'K' || letter == 'V' || letter == 'X' || letter == 'Z' || letter == 'J' || letter == 'Q')
                {
                    scoreLetter += bonusE; continue;
                }
            }

            return (int)scoreLetter;
        }
        //static void Main(string[] args)
        //{
        //    Stopwatch stopWatch = new Stopwatch();


        //    StreamReader readFile = new StreamReader(@"..\..\files\words.txt");
        //    StreamWriter writeFile = new StreamWriter(@"..\..\files\words_with_score.txt");

        //    stopWatch.Start();
        //    using (readFile)
        //    {
        //        using (writeFile)
        //        {
        //            string word = readFile.ReadLine();
        //            while (word != null)
        //            {
        //                writeFile.WriteLine("{0, -3} {1} ", ScoreLetters(word), word);
        //                word = readFile.ReadLine();
        //            }
        //        }
        //    }
        //    stopWatch.Stop();

        //    Console.WriteLine("Used time for calculation is {0} miliseconds ({1} ticks)", stopWatch.ElapsedMilliseconds, stopWatch.ElapsedTicks);

        //}
    }
}
