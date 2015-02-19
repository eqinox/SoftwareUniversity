using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace TheGame
{
    class BrainGame
    {
        private  const ConsoleColor wordsColor = ConsoleColor.Yellow; // cvetut v koito sa vsi4ki bukvi
        private const ConsoleColor borderColor = ConsoleColor.Green; // cvetut v koito e ramkata na inputa i igralnoto pole
        public const int worldRows = 15;
        public const int worldCols = 30;
        private  const int sleepTime = 500;
        private  const int maxLevel = 7;
        private const int endLevel = 0;
        private const int maxLevelWords = 5;
        private const int startLevel = 1;
        private const int startResult = 0;

        private const string gameName = "Speedy mind";

        private static GameField gameField;
        private static ConsoleRenderer renderer;
        private static int wordsToNextLevel = 5;
        private static int currentLevel = 1;  //  TODO changing levels
        private static int result = 0;
        private static int apearText = 0;
        private static int dissapearText = 2000;


        static void Main()
        {
            Console.Title = gameName;
            Console.WindowHeight = 25;
            Console.WindowWidth = 60;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            List<string> allWords = new List<string>();
            StreamReader readWords = new StreamReader("../../files/Words.txt");
            gameField = new GameField(worldCols, worldRows);
            ReadWords(allWords, readWords);
            var wordsByLength = GetWordsByLength(allWords);
            
            string word = GetWordByLevel(currentLevel, wordsByLength);
            renderer = new ConsoleRenderer(gameField);
            renderer.PrintBox(borderColor);
            renderer.DrawMatrix(borderColor);
            StringBuilder theWord = new StringBuilder(); // tuk se zapisva, tova koeto usera vuvejda
            Random wordPosition = new Random();


            while (true)
            {
                

                PrintResult();
                word = GetWordByLevel(currentLevel, wordsByLength);
                int wordPos = wordPosition.Next(2, worldCols - word.Length - 2); // ot koq kolonka da pada dumata
                DrawCurrentLevel();
                for (int i = 1; i < worldRows - 1; i++)
                {
                    Thread.Sleep(sleepTime);
                    renderer.Draw(wordPos, i, word, wordsColor);
                    Console.SetCursorPosition(worldCols/2 - (ConsoleRenderer.inputBoxLenght / 2) + theWord.Length, worldRows + 1);
                    while (Console.KeyAvailable)
                    {
                        Console.ForegroundColor = wordsColor;
                        ConsoleKeyInfo currentSymbolInput = Console.ReadKey();
                        
                        if (currentSymbolInput.Key == ConsoleKey.Backspace) // ako natisne backspace se trie poslednata bukva ot dumata koqto sme napisali do momenta
                        {
                            if (theWord.Length > 0)
                            {
                                theWord.Length--;
                            }
                            Console.SetCursorPosition(worldCols / 2 - (ConsoleRenderer.inputBoxLenght / 2) + theWord.Length, worldRows + 1);
                            Console.Write(" ");
                        }
                        else if (char.IsLetter((char)currentSymbolInput.Key) // kogato vuvede6 bukva, cifra ili space
                            || char.IsDigit((char)currentSymbolInput.Key)
                            || currentSymbolInput.Key == ConsoleKey.Spacebar)
                        {
                            if (currentSymbolInput.Key == ConsoleKey.Spacebar)
                            {
                                theWord.Append(' ');
                            }
                            else
                            {
                                theWord.Append(currentSymbolInput.Key);
                            }
                        }
                        else if (currentSymbolInput.Key == ConsoleKey.Enter)
                        {
                            if (theWord.ToString().ToLower() == word.ToLower())
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(worldCols + 5, 7);
                                Console.WriteLine("Correct ");
                                System.Threading.Thread.Sleep(1000);
                                result+=Score.ScoreLetters(word); //ocenava dumata s klasa score
                                //result++;
                                wordsToNextLevel--;
                                CheckForNextLevel();
                                theWord.Clear();
                                //Console.ReadLine();
                                //Console.Clear();
                                renderer.PrintBox(borderColor);
                                renderer.DrawMatrix(borderColor);
                                i = 200; // to exit instant of the For cycle
                                break;
                            }
                            else // samo kogato sburka6 duma
                            {
                                WhenYouLose(theWord);
                                i = 200; // to exit instant of the For cycle
                                break;

                            }
                        }
                    } EndGame(i, theWord);
                }
            }
        }

        private static void WhenYouLose(StringBuilder theWord)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(worldCols + 5, 7);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You Lose");
            result = startResult;//vmesto 0
            currentLevel = startLevel;// vmesto 1
            wordsToNextLevel = maxLevelWords; // vmesto 5
            theWord.Clear();
            //Console.ReadLine();
            //Console.Clear();
            renderer.PrintBox(borderColor);
            renderer.DrawMatrix(borderColor);
        }


        private static void EndGame(int row, StringBuilder theWord)
        {
            if (row == worldRows - 2)
            {
                WhenYouLose(theWord);
            }
        }
        public static void PrintResult()
        {
            Console.SetCursorPosition(worldCols + 5, 6);
            Console.ForegroundColor = wordsColor;
            if (result < 0)
            {
                result = 0;
            }
            Console.WriteLine("{0} points", result);
        }

        private static void DrawCurrentLevel()
        {
            Console.SetCursorPosition(worldCols + 5, 5);
            Console.ForegroundColor = wordsColor;
            Console.Write("Current level: {0}", currentLevel);
        }

        private static void CheckForNextLevel()
        {
            if (wordsToNextLevel == endLevel) // beshe 0, slojih const(PetrK)
            {
                currentLevel++;
                wordsToNextLevel = maxLevelWords; // beshe 5, slojih const(PetrK)
            }
        }
        private static string GetWordByLevel(int level, List<List<string>> wordsByLength)
        {
            string result;
            float factor = (float)wordsByLength.Count / maxLevel;
            int index = (int)(level * factor);
            int minIndex = index - 1;
            int maxIndex = index + 1;
            if (minIndex < 0)
            {
                minIndex = 0;
            }
            if (maxIndex >= wordsByLength.Count)
            {
                maxIndex = wordsByLength.Count - 1;
            }
            Random randomGenerator = new Random();
            index = randomGenerator.Next(minIndex, maxIndex + 1);
            result = wordsByLength[index][randomGenerator.Next(0, wordsByLength[index].Count)];
            return result;
        }

        private static void ReadWords(List<string> allWords, StreamReader readWords)
        {
            using (readWords)
            {
                for (string word = readWords.ReadLine(); word != null; word = readWords.ReadLine())
                {
                    allWords.Add(word);
                }
            }
            allWords.Sort();
        }

        private static List<List<string>> GetWordsByLength(List<string> allWords)
        {
            if (allWords.Count == 0)
            {
                throw new ArgumentException("There are no words :)");
            }
            allWords.Sort((x, y) => x.Length.CompareTo(y.Length));
            List<List<string>> result = new List<List<string>>();
            result.Add(new List<string>());
            for (int i = 0, j = 0; i < allWords.Count; i++)
            {
                string currentWord = allWords[i];
                if (result[j].Count > 0 && currentWord.Length != result[j][0].Length)
                {
                    j++;
                    result.Add(new List<string>());
                }
                result[j].Add(currentWord);
            }
            return result;
        }
    }
}
