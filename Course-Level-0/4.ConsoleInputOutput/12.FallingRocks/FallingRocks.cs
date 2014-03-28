using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12.FallingRocks
{
    class FallingRocks
    {
        private static int playerXPosition = Console.WindowWidth / 2;
        private static int playerYPosition = Console.WindowHeight - 1;
        private static string playerSymbol = "(0)";
        private static char[] enemySymbols = new char[] { '+', '#', ';', '*', '$', '@', '^', '&', '%', '!', '.'};
        private static List<Enemy> enemies = new List<Enemy>();
        static void Main(string[] args)
        {
            Engine();
        }

        private static void Engine()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            while (true)
            {
                DrawPlayer();
                MovePlayer();
                DrawEnemy();
                ColissionWithPlayer();
                Thread.Sleep(150);
            }
        }

        private static void DrawPlayer()
        {
            for (int i = playerXPosition; i < playerXPosition + playerSymbol.Length; i++)
            {
                Console.SetCursorPosition(i, playerYPosition);
                Console.Write(playerSymbol[i - playerXPosition]);
                Console.Write(' ');
            }
            
        }

        private static void MovePlayer()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.RightArrow)
                {
                    if (playerXPosition < Console.WindowWidth - playerSymbol.Length - 2)
                    {
                        Console.SetCursorPosition(playerXPosition, playerYPosition);
                        Console.Write(" ");
                        playerXPosition++;
                    }
                }
                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    if (playerXPosition > 0)
                    {
                        Console.SetCursorPosition(playerXPosition + playerSymbol.Length, playerYPosition);
                        Console.Write(" ");
                        playerXPosition--;
                    }
                }
            }
        }

        private static void DrawEnemy()
        {
            Random randomX = new Random();
            enemies.Add(new Enemy()
            {
                X = randomX.Next(0, Console.WindowWidth - 1),
                Y = 1,
                Symbol = enemySymbols[randomX.Next(0, enemySymbols.Length - 1)]
            });
            for (int i = 0; i < enemies.Count; i++)
            {

                if (enemies[i].Y == Console.WindowHeight)
                {
                    Console.SetCursorPosition(enemies[i].X, enemies[i].Y - 1);
                    Console.Write(' ');
                    enemies.RemoveAt(i);
                }
                else
                {
                    Console.SetCursorPosition(enemies[i].X, enemies[i].Y - 1);
                    Console.Write(' ');
                    Console.SetCursorPosition(enemies[i].X, enemies[i].Y);
                    Console.Write(enemies[i].Symbol);
                    enemies[i].Y++;
                }
            }
        }

        private static void ColissionWithPlayer()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Y == playerYPosition && (enemies[i].X == playerXPosition + 1 || enemies[i].X == playerXPosition || enemies[i].X == playerXPosition + 2))
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.WriteLine("GAME OVER");
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + 1);
                    Console.WriteLine("PRESS ENTER TO CONTINUE");
                    Console.ReadLine();
                    Console.Clear();
                    enemies = new List<Enemy>();
                    playerXPosition = Console.WindowWidth / 2;
                    playerYPosition = Console.WindowHeight - 1;
                }
            }
        }
    }
}
