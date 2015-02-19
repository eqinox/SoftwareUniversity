using System;
using System.Threading;
using System.IO;
using System.Media;

namespace TheGame
{
    class PacMan
    {
        static Player hero = new Player();
        static Player oponent1 = new Player();
        static Player oponent2 = new Player();
        static Player oponent3 = new Player();
        static Player oponent4 = new Player();
        static int[,] gameField = new int[59, 35];
        static int score = 0;
        static int lives = 3;
        static int counterPercentage = 0;
        static int percentage = 4;
        static int hibernateTime = 0;
        static bool redGreenBlink = false;
        static bool turnOnTheEnemy4 = false; // when to activate enemy 4 start moving
        static int currentBonusLive = 0;
        static int totalPoints;
        static SoundPlayer StartMusic = new SoundPlayer(@"..\..\StartMusic.wav");
        static SoundPlayer startmusicold = new SoundPlayer(@"..\..\startmusicold.wav");
        static SoundPlayer ghosteat = new SoundPlayer(@"..\..\ghosteat.wav");
        static SoundPlayer killed = new SoundPlayer(@"..\..\killed.wav");
        static SoundPlayer EatPill = new SoundPlayer(@"..\..\EatPill.wav");
        static SoundPlayer extralife = new SoundPlayer(@"..\..\extralife.wav");
        static void Main()
        {
            using (StartMusic)
            {
                StartMusic.Play();
                Menu();
                Settings();
                RenderFields();
                Engine();
            }
        }
        static void Engine()
        {

            DrawPlayer();
            DrawOponents();
            while (true)
            {

                Thread.Sleep(150);

                DrawOponents();
                PlayerCollisionWithWall();
                OponentsCollisionWithWall();
                DrawScore();
                MoveOponents();
                PlayerOponentCollision();
                MovePlayer();
                PlayerOponentCollision();

            }
        }
        static void Menu()
        {
            Console.SetWindowSize(59, 38);
            Console.SetBufferSize(59, 38);

            Console.SetCursorPosition(3, 5);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("******     *      ******  *       *     *     *     *");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("*     *    *     *      * **     **     *     **    *");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("*     *   * *    *      * * *   * *    * *    * *   *");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("*     *   * *    *        *  * *  *    * *    *  *  *");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("*     *  *   *   *        *   *   *   *   *   *   * *");
            Console.SetCursorPosition(3, 10);
            Console.WriteLine("******   *   *   *        *       *   *   *   *    **");
            Console.SetCursorPosition(3, 11);
            Console.WriteLine("*       *******  *        *       *  *******  *     *");
            Console.SetCursorPosition(3, 12);
            Console.WriteLine("*       *     *  *      * *       *  *     *  *     *");
            Console.SetCursorPosition(3, 13);
            Console.WriteLine("*      *       * *      * *       * *       * *     *");
            Console.SetCursorPosition(3, 14);
            Console.WriteLine("*      *       *  ******  *       * *       * *     *");
            Console.ResetColor();
            Console.SetCursorPosition(15, 18);
            Console.WriteLine("За начало напишете - start ");
            Console.SetCursorPosition(4, 20);
            Console.WriteLine("За начало с желана трудност напишете - easy / hard ");
            Console.SetCursorPosition(17, 22);
            Console.WriteLine("За изход напишете - exit ");
            Console.SetCursorPosition(25, 24);
            string command = Console.ReadLine();
            while (true)
            {
                if (command == "start")
                {
                    Console.Clear();
                    break;
                }
                else if (command == "easy")
                {
                    percentage = 2;
                    Console.Clear();
                    break;
                }
                else if (command == "hard")
                {
                    percentage = 20;
                    Console.Clear();
                    break;
                }
                else if (command == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.SetCursorPosition(20, 22);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Невалидна команда!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    Main();
                }
                //Console.SetCursorPosition(25, 24);
                //command = Console.ReadLine();
            }

        }


        static void DrawScore()
        {
            WinMassage();
            if (score >= 900)
            {
                currentBonusLive++;
                if (currentBonusLive == 1)
                {
                    using (extralife)
                    {
                        extralife.Play();
                        lives++;
                    }
                }
                if (currentBonusLive == 1000)
                {
                    currentBonusLive = 2;
                }
            }
            Console.SetCursorPosition(10, 35);
            Console.Write("Score: " + score);
            Console.SetCursorPosition(40, 35);
            Console.Write("Lives: " + lives);
            if (lives == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(24, 18);
                Console.WriteLine("GAME OVER");
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("Твоят резултат е: {0}", score);
                Console.SetCursorPosition(15, 23);
                Console.WriteLine("За да продължиш натисни Enter");
                ConsoleKeyInfo restart = new ConsoleKeyInfo();
                
                while (true)
                {
                    restart = Console.ReadKey();
                    if (restart.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        score = 0;
                        lives = 3;
                        currentBonusLive = 0;
                        Main(); 
                    }
                }
            }
        }

        private static void WinMassage()
        {
            if (totalPoints <= 0)
            {
                Console.Clear();
                Console.SetCursorPosition(24, 18);
                Console.WriteLine("Печелиш");
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("Твоят резултат е: {0}", score);
                Console.SetCursorPosition(15, 23);
                Console.WriteLine("За нова игра натисни Enter");
                ConsoleKeyInfo restart = new ConsoleKeyInfo();

                while (true)
                {
                    restart = Console.ReadKey();
                    if (restart.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        score = 0;
                        lives = 3;
                        currentBonusLive = 0;
                        Main();
                    }
                }
            }
        }

        static void PlayerOponentCollision()
        {
            if (hero.XPosition == oponent1.XPosition && hero.YPosition == oponent1.YPosition
                || hero.XPosition == oponent2.XPosition && hero.YPosition == oponent2.YPosition
                || hero.XPosition == oponent3.XPosition && hero.YPosition == oponent3.YPosition
                || hero.XPosition == oponent4.XPosition && hero.YPosition == oponent4.YPosition)
            {
                if (hibernateTime > 0)
                {
                    using (ghosteat)
                    {
                        ghosteat.Play();
                    }
                    score += 25;
                    return;
                }
                using (killed)
                {
                    killed.Play();
                }
                turnOnTheEnemy4 = false;
                lives--;
                Console.SetCursorPosition(hero.XPosition, hero.YPosition);
                Console.Write(' ');
                Console.SetCursorPosition(oponent1.XPosition, oponent1.YPosition);
                Console.Write(' ');
                Console.SetCursorPosition(oponent2.XPosition, oponent2.YPosition);
                Console.Write(' ');
                Console.SetCursorPosition(oponent3.XPosition, oponent3.YPosition);
                Console.Write(' ');
                Console.SetCursorPosition(oponent4.XPosition, oponent4.YPosition);
                Console.Write(' ');
                Settings();
                Engine();
            }
        }

        private static void MovePlayer()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = new ConsoleKeyInfo();
                userInput = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    hero.CurrentDirection = "Right";
                }
                else if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    hero.CurrentDirection = "Left";
                }
                else if (userInput.Key == ConsoleKey.UpArrow)
                {
                    hero.CurrentDirection = "Up";
                }
                else if (userInput.Key == ConsoleKey.DownArrow)
                {
                    hero.CurrentDirection = "Down";
                }
            }


            if (hero.CurrentDirection == "Right")
            {
                if (hero.AllowToMoveRight)
                {
                    if (gameField[hero.XPosition + 1, hero.YPosition] == 100)
                    {
                        using (EatPill)
                        {
                            EatPill.Play();
                        }
                        gameField[hero.XPosition + 1, hero.YPosition] = 0;
                        score++;
                        totalPoints--;
                    }
                    else if (gameField[hero.XPosition + 1, hero.YPosition] == 72)
                    {
                        using (startmusicold)
                        {
                            startmusicold.Play();
                        }
                        gameField[hero.XPosition + 1, hero.YPosition] = 0;
                        score += 50;
                        hibernateTime = 50;
                    }
                    hero.MoveRight();
                }
            }
            else if (hero.CurrentDirection == "Left")
            {
                if (hero.AllowToMoveLeft)
                {
                    if (gameField[hero.XPosition - 1, hero.YPosition] == 100)
                    {
                        using (EatPill)
                        {
                            EatPill.Play();
                        }
                        gameField[hero.XPosition - 1, hero.YPosition] = 0;
                        score++;
                        totalPoints--;
                    }
                    else if (gameField[hero.XPosition - 1, hero.YPosition] == 72)
                    {
                        using (startmusicold)
                        {
                            startmusicold.Play();
                        }
                        gameField[hero.XPosition - 1, hero.YPosition] = 0;
                        score++;
                        hibernateTime = 50;
                    }
                    hero.MoveLeft();
                }
            }
            else if (hero.CurrentDirection == "Up")
            {
                if (hero.AllowToMoveUp)
                {
                    if (gameField[hero.XPosition, hero.YPosition - 1] == 100)
                    {
                        using (EatPill)
                        {
                            EatPill.Play();
                        }
                        gameField[hero.XPosition, hero.YPosition - 1] = 0;
                        score++;
                        totalPoints--;
                    }
                    else if (gameField[hero.XPosition, hero.YPosition - 1] == 72)
                    {
                        using (startmusicold)
                        {
                            startmusicold.Play();
                        }
                        gameField[hero.XPosition, hero.YPosition - 1] = 0;
                        score++;
                        hibernateTime = 50;
                    }
                    hero.MoveUp();
                }
            }
            else if (hero.CurrentDirection == "Down")
            {
                if (hero.AllowToMoveDown)
                {
                    if (gameField[hero.XPosition, hero.YPosition + 1] == 100)
                    {
                        using (EatPill)
                        {
                            EatPill.Play();
                        }
                        gameField[hero.XPosition, hero.YPosition + 1] = 0;
                        score++;
                        totalPoints--;
                    }
                    else if (gameField[hero.XPosition, hero.YPosition + 1] == 72)
                    {
                        using (startmusicold)
                        {
                            startmusicold.Play();
                        }
                        gameField[hero.XPosition, hero.YPosition + 1] = 0;
                        score++;
                        hibernateTime = 50;
                    }
                    hero.MoveDown();
                }
            }
        }


        static void Settings()
        {
            // set console size, remove scrollbars, set title
            Console.Title = "PacMan";
            Console.SetWindowSize(59, 38);
            Console.SetBufferSize(59, 38);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;

            oponent1.XPosition = Console.WindowWidth / 2;
            oponent1.YPosition = Console.WindowHeight - 22;
            oponent1.CurrentDirection = "Up";
            oponent1.Color = ConsoleColor.Red;
            oponent1.Symbol = '@';

            oponent2.XPosition = Console.WindowWidth / 2;
            oponent2.YPosition = Console.WindowHeight - 22;
            oponent2.CurrentDirection = "Up";
            oponent2.Color = ConsoleColor.Magenta;
            oponent2.Symbol = '@';

            oponent3.XPosition = Console.WindowWidth / 2;
            oponent3.YPosition = Console.WindowHeight - 22;
            oponent3.CurrentDirection = "Up";
            oponent3.Color = ConsoleColor.White;
            oponent3.Symbol = '@';

            oponent4.XPosition = Console.WindowWidth / 2;
            oponent4.YPosition = Console.WindowHeight - 22;
            oponent4.CurrentDirection = "Up";
            oponent4.Color = ConsoleColor.Blue;
            oponent4.Symbol = '@';

            hero.XPosition = Console.WindowWidth / 2;
            hero.YPosition = Console.WindowHeight - 17;
            hero.CurrentDirection = "Up";
            hero.Color = ConsoleColor.Green;
            hero.Symbol = 'O';
        }


        static void MoveOponents()
        {
            Random randomGenerator = new Random();
            int next = randomGenerator.Next(1, 50);
            if (hibernateTime > 0)//hibernate oponent when char"H" reached
            {
                hibernateTime--;
                oponent1.Color = ConsoleColor.Green;
                oponent2.Color = ConsoleColor.Green;
                oponent3.Color = ConsoleColor.Green;
                oponent4.Color = ConsoleColor.Green;
                if (hibernateTime < 16 && redGreenBlink)
                {
                    oponent1.Color = ConsoleColor.Red;
                    oponent2.Color = ConsoleColor.Magenta;
                    oponent3.Color = ConsoleColor.White;
                    oponent4.Color = ConsoleColor.Blue;
                }
                redGreenBlink = !redGreenBlink;
                oponent1.HoldOn();
                oponent2.HoldOn();
                oponent3.HoldOn();
                oponent4.HoldOn();
                return;

            }
            if (counterPercentage == percentage)//decrease oponent speed
            {
                counterPercentage = 0;
                oponent1.HoldOn();
                oponent2.HoldOn();
                oponent3.HoldOn();
                oponent4.HoldOn();
                return;
            }
            counterPercentage++;

            MoveOponent1();

            MoveOponent2();

            MoveOponent3();
            if (next == 25)
            {
                turnOnTheEnemy4 = true;
            }
            if (turnOnTheEnemy4)
            {
                MoveOponent4();
            }
        }

        private static void MoveOponent4()
        {
            if ((oponent4.YPosition >= 14 && oponent4.YPosition <= 20) && oponent4.XPosition >= 23 && oponent4.XPosition <= 35) // if they are in the middle
            {
                oponent4.CurrentDirection = "Up";
            }
            if (oponent4.CurrentDirection == "Up")
            {
                if (oponent4.AllowToMoveUp)
                {
                    oponent4.MoveUp();
                    if (gameField[oponent4.XPosition, oponent4.YPosition + 1] == 100)
                    {
                        Console.SetCursorPosition(oponent4.XPosition, oponent4.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent4.XPosition, oponent4.YPosition + 1] == 72)
                    {
                        Console.SetCursorPosition(oponent4.XPosition, oponent4.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent4.XPosition, oponent4.YPosition - 1] == 1000) // if hit in wall
                {
                    if (gameField[oponent4.XPosition + 2, oponent4.YPosition] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Left";
                    }
                    else if (gameField[oponent4.XPosition - 2, oponent4.YPosition] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition > oponent4.XPosition) // compare with player
                    {
                        oponent4.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent4.XPosition) // compare with player
                    {
                        oponent4.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent4.XPosition - 2, oponent4.YPosition] != 1000) && gameField[oponent4.XPosition + 1, oponent4.YPosition] != 1000) // if there are emptu line
                {
                    if (hero.XPosition > oponent4.XPosition && (gameField[oponent4.XPosition + 2, oponent4.YPosition] != 1000)) // empty line
                    {
                        oponent4.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent4.XPosition && (gameField[oponent4.XPosition - 2, oponent4.YPosition] != 1000))
                    {
                        oponent4.CurrentDirection = "Left";
                        if (hero.YPosition < oponent4.YPosition && oponent4.XPosition == 13)
                        {
                            oponent4.CurrentDirection = "Up";
                        }
                    }
                }
                else if ((gameField[oponent4.XPosition - 1, oponent4.YPosition] != 1000) && (gameField[oponent4.XPosition + 2, oponent4.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent4.XPosition) // empty line
                    {
                        oponent4.CurrentDirection = "Right";
                        if (hero.YPosition < oponent4.YPosition && oponent4.XPosition == 45)
                        {
                            oponent4.CurrentDirection = "Up";
                        }
                    }
                    else
                    {
                        oponent4.CurrentDirection = "Left";
                    }
                }

            }
            else if (oponent4.CurrentDirection == "Down")
            {
                if (oponent4.AllowToMoveDown)
                {
                    oponent4.MoveDown();
                    if (gameField[oponent4.XPosition, oponent4.YPosition - 1] == 100)
                    {
                        Console.SetCursorPosition(oponent4.XPosition, oponent4.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent4.XPosition, oponent4.YPosition - 1] == 72)
                    {
                        Console.SetCursorPosition(oponent4.XPosition, oponent4.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent4.XPosition, oponent4.YPosition + 1] == 1000) // if hit in wall
                {
                    if (gameField[oponent4.XPosition + 2, oponent4.YPosition] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Left";
                    }
                    else if (gameField[oponent4.XPosition - 2, oponent4.YPosition] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition > oponent4.XPosition) // compare with player
                    {
                        oponent4.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent4.XPosition) // compare with player
                    {
                        oponent4.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent4.XPosition - 2, oponent4.YPosition] != 1000) && gameField[oponent4.XPosition + 1, oponent4.YPosition] != 1000) // if there are emptu line
                {
                    if (hero.XPosition > oponent4.XPosition && (gameField[oponent4.XPosition + 2, oponent4.YPosition] != 1000)) // empty line
                    {
                        oponent4.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent4.XPosition && (gameField[oponent4.XPosition - 2, oponent4.YPosition] != 1000))
                    {
                        oponent4.CurrentDirection = "Left";
                        if (hero.YPosition > oponent4.YPosition && oponent4.XPosition == 13)
                        {
                            oponent4.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent4.XPosition - 1, oponent4.YPosition] != 1000) && (gameField[oponent4.XPosition + 2, oponent4.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent4.XPosition) // empty line
                    {
                        oponent4.CurrentDirection = "Right";
                        if (hero.YPosition > oponent4.YPosition && oponent4.XPosition == 45)
                        {
                            oponent4.CurrentDirection = "Down";
                        }
                    }
                    else
                    {
                        oponent4.CurrentDirection = "Left";
                        if (hero.YPosition > oponent4.YPosition && oponent4.XPosition == 13)
                        {
                            oponent4.CurrentDirection = "Down";
                        }
                    }
                }
            }
            else if (oponent4.CurrentDirection == "Right")
            {
                if (oponent4.AllowToMoveRight)
                {
                    oponent4.MoveRight();
                    if (gameField[oponent4.XPosition - 1, oponent4.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent4.XPosition - 1, oponent4.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent4.XPosition - 1, oponent4.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent4.XPosition - 1, oponent4.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent4.XPosition + 2, oponent4.YPosition] == 1000) // compare if hit a wall
                {
                    if (gameField[oponent4.XPosition, oponent4.YPosition - 1] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent4.XPosition, oponent4.YPosition + 1] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent4.YPosition)
                    {
                        oponent4.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent4.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent4.XPosition, oponent4.YPosition - 1] == 1000) && (gameField[oponent4.XPosition, oponent4.YPosition + 1] != 1000)) // if there are empty line on bottom
                {
                    if (hero.YPosition > oponent4.YPosition)// if there are empty line on bottom
                    {
                        if (oponent4.YPosition != 13 && oponent4.XPosition != 31 && (gameField[oponent4.XPosition + 1, oponent4.YPosition + 1] != 1000)) // if its in the middle
                        {
                            oponent4.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent4.XPosition, oponent4.YPosition + 1] == 1000) && (gameField[oponent4.XPosition, oponent4.YPosition - 1] != 1000)) // if there are empty line on Top
                {
                    if (hero.YPosition < oponent4.YPosition && (gameField[oponent4.XPosition + 1, oponent4.YPosition - 1] != 1000)) // if there are empty line on Top
                    {
                        oponent4.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent4.XPosition, oponent4.YPosition + 1] != 1000) && (gameField[oponent4.XPosition, oponent4.YPosition - 1] != 1000)) // if there are empry line on both sides
                {
                    if (hero.YPosition < oponent4.YPosition && (gameField[oponent4.XPosition + 1, oponent4.YPosition + 1] != 1000)
                        && (gameField[oponent4.XPosition + 1, oponent4.YPosition - 1] != 1000)) // if there are empry line on both sides
                    {
                        oponent4.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent4.YPosition && (gameField[oponent4.XPosition + 1, oponent4.YPosition + 1] != 1000)
                        && (gameField[oponent4.XPosition + 1, oponent4.YPosition - 1] != 1000)) // if there are empry line on both sides
                    {
                        oponent4.CurrentDirection = "Down";
                    }
                }
            }
            else if (oponent4.CurrentDirection == "Left")
            {
                if (oponent4.AllowToMoveLeft)
                {
                    oponent4.MoveLeft();
                    if (gameField[oponent4.XPosition + 1, oponent4.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent4.XPosition + 1, oponent4.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent4.XPosition + 1, oponent4.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent4.XPosition + 1, oponent4.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent4.XPosition - 2, oponent4.YPosition] == 1000) // if hit a wall
                {
                    if (gameField[oponent4.XPosition, oponent4.YPosition - 1] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent4.XPosition, oponent4.YPosition + 1] == 1000) // if no way
                    {
                        oponent4.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent4.YPosition)
                    {
                        oponent4.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent4.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent4.XPosition, oponent4.YPosition + 1] == 1000) && (gameField[oponent4.XPosition, oponent4.YPosition - 1] != 1000)) // if there are empty line on top
                {
                    if (hero.YPosition < oponent4.YPosition) // if there are empty line on top
                    {
                        oponent4.CurrentDirection = "Up";
                        if (hero.XPosition < oponent4.XPosition && oponent4.YPosition == 5)
                        {
                            oponent4.CurrentDirection = "Left";
                        }
                    }
                }
                else if ((gameField[oponent4.XPosition, oponent4.YPosition - 1] == 1000) && (gameField[oponent4.XPosition, oponent4.YPosition + 1] != 1000)) // if there are empty line on Bottom
                {
                    if (hero.YPosition > oponent4.YPosition) // if there are empty line on Bottom
                    {
                        if (oponent4.YPosition != 13 && oponent4.XPosition != 27) // if its in the middle
                        {
                            oponent4.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent4.XPosition, oponent4.YPosition + 1] != 1000) && (gameField[oponent4.XPosition, oponent4.YPosition - 1] != 1000)) // if there are empty line on both sides
                {
                    if (hero.YPosition < oponent4.YPosition && (gameField[oponent4.XPosition - 1, oponent4.YPosition + 1] != 1000) &&
                        (gameField[oponent4.XPosition - 1, oponent4.YPosition - 1] != 1000)) // if there are empty line on both sides
                    {
                        oponent4.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent4.YPosition && (gameField[oponent4.XPosition - 1, oponent4.YPosition + 1] != 1000) &&
                        (gameField[oponent4.XPosition - 1, oponent4.YPosition - 1] != 1000)) // if there are empty line on both sides
                    {
                        oponent4.CurrentDirection = "Down";
                    }
                }
            }
        }

        private static void MoveOponent3()
        {
            if ((oponent3.YPosition >= 14 && oponent3.YPosition <= 20) && oponent3.XPosition >= 23 && oponent3.XPosition <= 35) // if they are in the middle
            {
                oponent3.CurrentDirection = "Up";
            }
            if (oponent3.CurrentDirection == "Up")
            {
                if (oponent3.AllowToMoveUp)
                {
                    oponent3.MoveUp();
                    if (gameField[oponent3.XPosition, oponent3.YPosition + 1] == 100)
                    {
                        Console.SetCursorPosition(oponent3.XPosition, oponent3.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent3.XPosition, oponent3.YPosition + 1] == 72)
                    {
                        Console.SetCursorPosition(oponent3.XPosition, oponent3.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent3.XPosition, oponent3.YPosition - 1] == 1000)
                {
                    if (gameField[oponent3.XPosition + 2, oponent3.YPosition] == 1000)
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                    else if (gameField[oponent3.XPosition - 2, oponent3.YPosition] == 1000)
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else if (hero.CurrentLocation == "DownRight" || hero.CurrentLocation == "UpRight")
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else if (hero.CurrentLocation == "DownLeft" || hero.CurrentLocation == "UpLeft")
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent3.XPosition - 2, oponent3.YPosition] != 1000) && gameField[oponent3.XPosition + 1, oponent3.YPosition] != 1000)
                {
                    if (hero.XPosition > oponent3.XPosition)
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent3.XPosition - 1, oponent3.YPosition] != 1000) && (gameField[oponent3.XPosition + 2, oponent3.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent3.XPosition)
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                }

            }
            else if (oponent3.CurrentDirection == "Down")
            {
                if (oponent3.AllowToMoveDown)
                {
                    oponent3.MoveDown();
                    if (gameField[oponent3.XPosition, oponent3.YPosition - 1] == 100)
                    {
                        Console.SetCursorPosition(oponent3.XPosition, oponent3.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent3.XPosition, oponent3.YPosition - 1] == 72)
                    {
                        Console.SetCursorPosition(oponent3.XPosition, oponent3.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent3.XPosition, oponent3.YPosition + 1] == 1000)
                {
                    if (gameField[oponent3.XPosition + 2, oponent3.YPosition] == 1000)
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                    else if (gameField[oponent3.XPosition - 2, oponent3.YPosition] == 1000)
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else if (hero.CurrentLocation == "DownRight" || hero.CurrentLocation == "UpRight")
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else if (hero.CurrentLocation == "DownLeft" || hero.CurrentLocation == "UpLeft")
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent3.XPosition - 2, oponent3.YPosition] != 1000) && gameField[oponent3.XPosition + 1, oponent3.YPosition] != 1000)
                {
                    if (hero.XPosition > oponent3.XPosition)
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent3.XPosition - 1, oponent3.YPosition] != 1000) && (gameField[oponent3.XPosition + 2, oponent3.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent3.XPosition)
                    {
                        oponent3.CurrentDirection = "Right";
                    }
                    else
                    {
                        oponent3.CurrentDirection = "Left";
                    }
                }
            }
            else if (oponent3.CurrentDirection == "Right")
            {
                if (oponent3.AllowToMoveRight)
                {
                    oponent3.MoveRight();
                    if (gameField[oponent3.XPosition - 1, oponent3.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent3.XPosition - 1, oponent3.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent3.XPosition - 1, oponent3.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent3.XPosition - 1, oponent3.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent3.XPosition + 2, oponent3.YPosition] == 1000)
                {
                    if (gameField[oponent3.XPosition, oponent3.YPosition - 1] == 1000)
                    {
                        oponent3.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent3.XPosition, oponent3.YPosition + 1] == 1000)
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent3.XPosition, oponent3.YPosition - 1] == 1000) && (gameField[oponent3.XPosition, oponent3.YPosition + 1] != 1000))
                {
                    if (hero.YPosition > oponent3.YPosition)
                    {
                        if (oponent3.YPosition != 13 && oponent3.XPosition != 31)
                        {
                            oponent3.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent3.XPosition, oponent3.YPosition + 1] == 1000) && (gameField[oponent3.XPosition, oponent3.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent3.XPosition, oponent3.YPosition + 1] != 1000) && (gameField[oponent3.XPosition, oponent3.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Down";
                    }
                }
            }
            else if (oponent3.CurrentDirection == "Left")
            {
                if (oponent3.AllowToMoveLeft)
                {
                    oponent3.MoveLeft();
                    if (gameField[oponent3.XPosition + 1, oponent3.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent3.XPosition + 1, oponent3.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent3.XPosition + 1, oponent3.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent3.XPosition + 1, oponent3.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent3.XPosition - 2, oponent3.YPosition] == 1000)
                {
                    if (gameField[oponent3.XPosition, oponent3.YPosition - 1] == 1000)
                    {
                        oponent3.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent3.XPosition, oponent3.YPosition + 1] == 1000)
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent3.XPosition, oponent3.YPosition + 1] == 1000) && (gameField[oponent3.XPosition, oponent3.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent3.XPosition, oponent3.YPosition - 1] == 1000) && (gameField[oponent3.XPosition, oponent3.YPosition + 1] != 1000))
                {
                    if (hero.YPosition > oponent3.YPosition)
                    {
                        if (oponent3.YPosition != 13 && oponent3.XPosition == 27)
                        {
                            oponent3.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent3.XPosition, oponent3.YPosition + 1] != 1000) && (gameField[oponent3.XPosition, oponent3.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent3.YPosition)
                    {
                        oponent3.CurrentDirection = "Down";
                    }
                }
            }
        }

        private static void MoveOponent2()
        {

            if ((oponent2.YPosition >= 14 && oponent2.YPosition <= 20) && oponent2.XPosition >= 23 && oponent2.XPosition <= 35)
            {
                oponent2.CurrentDirection = "Up";
            }
            if (oponent2.CurrentDirection == "Up")
            {
                if (oponent2.AllowToMoveUp)
                {
                    oponent2.MoveUp();
                    if (gameField[oponent2.XPosition, oponent2.YPosition + 1] == 100)
                    {
                        Console.SetCursorPosition(oponent2.XPosition, oponent2.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent2.XPosition, oponent2.YPosition + 1] == 72)
                    {
                        Console.SetCursorPosition(oponent2.XPosition, oponent2.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent2.XPosition, oponent2.YPosition - 1] == 1000)
                {
                    if (gameField[oponent2.XPosition + 2, oponent2.YPosition] == 1000)
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                    else if (gameField[oponent2.XPosition - 2, oponent2.YPosition] == 1000)
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                    else if (hero.CurrentLocation == "DownRight" || hero.CurrentLocation == "UpRight")
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                    else if (hero.CurrentLocation == "DownLeft" || hero.CurrentLocation == "UpLeft")
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent2.XPosition - 2, oponent2.YPosition] != 1000) && gameField[oponent2.XPosition + 1, oponent2.YPosition] != 1000)
                {
                    if (hero.XPosition > oponent2.XPosition)
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                    else
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                }
                else if ((gameField[oponent2.XPosition - 1, oponent2.YPosition] != 1000) && (gameField[oponent2.XPosition + 2, oponent2.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent2.XPosition)
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                    else
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                }

            }
            else if (oponent2.CurrentDirection == "Down")
            {
                if (oponent2.AllowToMoveDown)
                {
                    oponent2.MoveDown();
                    if (gameField[oponent2.XPosition, oponent2.YPosition - 1] == 100)
                    {
                        Console.SetCursorPosition(oponent2.XPosition, oponent2.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent2.XPosition, oponent2.YPosition - 1] == 72)
                    {
                        Console.SetCursorPosition(oponent2.XPosition, oponent2.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent2.XPosition, oponent2.YPosition + 1] == 1000)
                {
                    if (gameField[oponent2.XPosition + 2, oponent2.YPosition] == 1000)
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                    else if (gameField[oponent2.XPosition - 2, oponent2.YPosition] == 1000)
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                    else if (hero.CurrentLocation == "DownRight" || hero.CurrentLocation == "UpRight")
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                    else if (hero.CurrentLocation == "DownLeft" || hero.CurrentLocation == "UpLeft")
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent2.XPosition - 2, oponent2.YPosition] != 1000) && gameField[oponent2.XPosition + 1, oponent2.YPosition] != 1000)
                {
                    if (hero.XPosition > oponent2.XPosition)
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                    else
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent2.XPosition - 1, oponent2.YPosition] != 1000) && (gameField[oponent2.XPosition + 2, oponent2.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent2.XPosition)
                    {
                        oponent2.CurrentDirection = "Right";
                    }
                    else
                    {
                        oponent2.CurrentDirection = "Left";
                    }
                }
            }
            else if (oponent2.CurrentDirection == "Right")
            {
                if (oponent2.AllowToMoveRight)
                {
                    oponent2.MoveRight();
                    if (gameField[oponent2.XPosition - 1, oponent2.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent2.XPosition - 1, oponent2.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent2.XPosition - 1, oponent2.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent2.XPosition - 1, oponent2.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent2.XPosition + 2, oponent2.YPosition] == 1000)
                {
                    if (gameField[oponent2.XPosition, oponent2.YPosition - 1] == 1000)
                    {
                        oponent2.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent2.XPosition, oponent2.YPosition + 1] == 1000)
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent2.XPosition, oponent2.YPosition - 1] == 1000) && (gameField[oponent2.XPosition, oponent2.YPosition + 1] != 1000))
                {
                    if (hero.YPosition > oponent2.YPosition)
                    {
                        if (oponent2.YPosition != 13 && oponent2.XPosition != 31)
                        {
                            oponent2.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent2.XPosition, oponent2.YPosition + 1] == 1000) && (gameField[oponent2.XPosition, oponent2.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent2.XPosition, oponent2.YPosition + 1] != 1000) && (gameField[oponent2.XPosition, oponent2.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Down";
                    }
                }
            }
            else if (oponent2.CurrentDirection == "Left")
            {
                if (oponent2.AllowToMoveLeft)
                {
                    oponent2.MoveLeft();
                    if (gameField[oponent2.XPosition + 1, oponent2.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent2.XPosition + 1, oponent2.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent2.XPosition + 1, oponent2.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent2.XPosition + 1, oponent2.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent2.XPosition - 2, oponent2.YPosition] == 1000)
                {
                    if (gameField[oponent2.XPosition, oponent2.YPosition - 1] == 1000)
                    {
                        oponent2.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent2.XPosition, oponent2.YPosition + 1] == 1000)
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent2.XPosition, oponent2.YPosition + 1] == 1000) && (gameField[oponent2.XPosition, oponent2.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent2.XPosition, oponent2.YPosition - 1] == 1000) && (gameField[oponent2.XPosition, oponent2.YPosition + 1] != 1000))
                {
                    if (hero.YPosition > oponent2.YPosition)
                    {
                        if (oponent2.YPosition != 13 && oponent2.XPosition == 27)
                        {
                            oponent2.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent2.XPosition, oponent2.YPosition + 1] != 1000) && (gameField[oponent2.XPosition, oponent2.YPosition - 1] != 1000))
                {
                    if (hero.YPosition < oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent2.YPosition)
                    {
                        oponent2.CurrentDirection = "Down";
                    }
                }
            }
        }

        private static void MoveOponent1()
        {
            if ((oponent1.YPosition >= 14 && oponent1.YPosition <= 20) && oponent1.XPosition >= 23 && oponent1.XPosition <= 35) // if they are in the middle
            {
                oponent1.CurrentDirection = "Up";
            }
            if (oponent1.CurrentDirection == "Up")
            {
                if (oponent1.AllowToMoveUp)
                {
                    oponent1.MoveUp();
                    if (gameField[oponent1.XPosition, oponent1.YPosition + 1] == 100)
                    {
                        Console.SetCursorPosition(oponent1.XPosition, oponent1.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent1.XPosition, oponent1.YPosition + 1] == 72)
                    {
                        Console.SetCursorPosition(oponent1.XPosition, oponent1.YPosition + 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent1.XPosition, oponent1.YPosition - 1] == 1000) // if hit in wall
                {
                    if (gameField[oponent1.XPosition + 2, oponent1.YPosition] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Left";
                    }
                    else if (gameField[oponent1.XPosition - 2, oponent1.YPosition] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition > oponent1.XPosition) // compare with player
                    {
                        oponent1.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent1.XPosition) // compare with player
                    {
                        oponent1.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent1.XPosition - 2, oponent1.YPosition] != 1000) && gameField[oponent1.XPosition + 1, oponent1.YPosition] != 1000) // if there are emptu line
                {
                    if (hero.XPosition > oponent1.XPosition && (gameField[oponent1.XPosition + 2, oponent1.YPosition] != 1000)) // empty line
                    {
                        oponent1.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent1.XPosition && (gameField[oponent1.XPosition - 2, oponent1.YPosition] != 1000))
                    {
                        oponent1.CurrentDirection = "Left";
                        if (hero.YPosition < oponent1.YPosition && oponent1.XPosition == 13)
                        {
                            oponent1.CurrentDirection = "Up";
                        }
                    }
                }
                else if ((gameField[oponent1.XPosition - 1, oponent1.YPosition] != 1000) && (gameField[oponent1.XPosition + 2, oponent1.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent1.XPosition) // empty line
                    {
                        oponent1.CurrentDirection = "Right";
                        if (hero.YPosition < oponent1.YPosition && oponent1.XPosition == 45)
                        {
                            oponent1.CurrentDirection = "Up";
                        }
                    }
                    else
                    {
                        oponent1.CurrentDirection = "Left";
                    }
                }

            }
            else if (oponent1.CurrentDirection == "Down")
            {
                if (oponent1.AllowToMoveDown)
                {
                    oponent1.MoveDown();
                    if (gameField[oponent1.XPosition, oponent1.YPosition - 1] == 100)
                    {
                        Console.SetCursorPosition(oponent1.XPosition, oponent1.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent1.XPosition, oponent1.YPosition - 1] == 72)
                    {
                        Console.SetCursorPosition(oponent1.XPosition, oponent1.YPosition - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent1.XPosition, oponent1.YPosition + 1] == 1000) // if hit in wall
                {
                    if (gameField[oponent1.XPosition + 2, oponent1.YPosition] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Left";
                    }
                    else if (gameField[oponent1.XPosition - 2, oponent1.YPosition] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition > oponent1.XPosition) // compare with player
                    {
                        oponent1.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent1.XPosition) // compare with player
                    {
                        oponent1.CurrentDirection = "Left";
                    }
                }
                else if ((gameField[oponent1.XPosition - 2, oponent1.YPosition] != 1000) && gameField[oponent1.XPosition + 1, oponent1.YPosition] != 1000) // if there are emptu line
                {
                    if (hero.XPosition > oponent1.XPosition && (gameField[oponent1.XPosition + 2, oponent1.YPosition] != 1000)) // empty line
                    {
                        oponent1.CurrentDirection = "Right";
                    }
                    else if (hero.XPosition < oponent1.XPosition && (gameField[oponent1.XPosition - 2, oponent1.YPosition] != 1000))
                    {
                        oponent1.CurrentDirection = "Left";
                        if (hero.YPosition > oponent1.YPosition && oponent1.XPosition == 13)
                        {
                            oponent1.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent1.XPosition - 1, oponent1.YPosition] != 1000) && (gameField[oponent1.XPosition + 2, oponent1.YPosition] != 1000))
                {
                    if (hero.XPosition > oponent1.XPosition) // empty line
                    {
                        oponent1.CurrentDirection = "Right";
                        if (hero.YPosition > oponent1.YPosition && oponent1.XPosition == 45)
                        {
                            oponent1.CurrentDirection = "Down";
                        }
                    }
                    else
                    {
                        oponent1.CurrentDirection = "Left";
                        if (hero.YPosition > oponent1.YPosition && oponent1.XPosition == 13)
                        {
                            oponent1.CurrentDirection = "Down";
                        }
                    }
                }
            }
            else if (oponent1.CurrentDirection == "Right")
            {
                if (oponent1.AllowToMoveRight)
                {
                    oponent1.MoveRight();
                    if (gameField[oponent1.XPosition - 1, oponent1.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent1.XPosition - 1, oponent1.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent1.XPosition - 1, oponent1.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent1.XPosition - 1, oponent1.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }
                if (gameField[oponent1.XPosition + 2, oponent1.YPosition] == 1000) // compare if hit a wall
                {
                    if (gameField[oponent1.XPosition, oponent1.YPosition - 1] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent1.XPosition, oponent1.YPosition + 1] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent1.YPosition)
                    {
                        oponent1.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent1.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent1.XPosition, oponent1.YPosition - 1] == 1000) && (gameField[oponent1.XPosition, oponent1.YPosition + 1] != 1000)) // if there are empty line on bottom
                {
                    if (hero.YPosition > oponent1.YPosition)// if there are empty line on bottom
                    {
                        if (oponent1.YPosition != 13 && oponent1.XPosition != 31 && (gameField[oponent1.XPosition + 1, oponent1.YPosition + 1] != 1000)) // if its in the middle
                        {
                            oponent1.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent1.XPosition, oponent1.YPosition + 1] == 1000) && (gameField[oponent1.XPosition, oponent1.YPosition - 1] != 1000)) // if there are empty line on Top
                {
                    if (hero.YPosition < oponent1.YPosition && (gameField[oponent1.XPosition + 1, oponent1.YPosition - 1] != 1000)) // if there are empty line on Top
                    {
                        oponent1.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent1.XPosition, oponent1.YPosition + 1] != 1000) && (gameField[oponent1.XPosition, oponent1.YPosition - 1] != 1000)) // if there are empry line on both sides
                {
                    if (hero.YPosition < oponent1.YPosition && (gameField[oponent1.XPosition + 1, oponent1.YPosition + 1] != 1000)
                        && (gameField[oponent1.XPosition + 1, oponent1.YPosition - 1] != 1000)) // if there are empry line on both sides
                    {
                        oponent1.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent1.YPosition && (gameField[oponent1.XPosition + 1, oponent1.YPosition + 1] != 1000)
                        && (gameField[oponent1.XPosition + 1, oponent1.YPosition - 1] != 1000)) // if there are empry line on both sides
                    {
                        oponent1.CurrentDirection = "Down";
                    }
                }
            }
            else if (oponent1.CurrentDirection == "Left")
            {
                if (oponent1.AllowToMoveLeft)
                {
                    oponent1.MoveLeft();
                    if (gameField[oponent1.XPosition + 1, oponent1.YPosition] == 100)
                    {
                        Console.SetCursorPosition(oponent1.XPosition + 1, oponent1.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('\'');
                        Console.ResetColor();
                    }
                    else if (gameField[oponent1.XPosition + 1, oponent1.YPosition] == 72)
                    {
                        Console.SetCursorPosition(oponent1.XPosition + 1, oponent1.YPosition);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('H');
                        Console.ResetColor();
                    }
                }

                if (gameField[oponent1.XPosition - 2, oponent1.YPosition] == 1000) // if hit a wall
                {
                    if (gameField[oponent1.XPosition, oponent1.YPosition - 1] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Down";
                    }
                    else if (gameField[oponent1.XPosition, oponent1.YPosition + 1] == 1000) // if no way
                    {
                        oponent1.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent1.YPosition)
                    {
                        oponent1.CurrentDirection = "Down";
                    }
                    else
                    {
                        oponent1.CurrentDirection = "Up";
                    }
                }
                else if ((gameField[oponent1.XPosition, oponent1.YPosition + 1] == 1000) && (gameField[oponent1.XPosition, oponent1.YPosition - 1] != 1000)) // if there are empty line on top
                {
                    if (hero.YPosition < oponent1.YPosition) // if there are empty line on top
                    {
                        oponent1.CurrentDirection = "Up";
                        if (hero.XPosition < oponent1.XPosition && oponent1.YPosition == 5)
                        {
                            oponent1.CurrentDirection = "Left";
                        }
                    }
                }
                else if ((gameField[oponent1.XPosition, oponent1.YPosition - 1] == 1000) && (gameField[oponent1.XPosition, oponent1.YPosition + 1] != 1000)) // if there are empty line on Bottom
                {
                    if (hero.YPosition > oponent1.YPosition) // if there are empty line on Bottom
                    {
                        if (oponent1.YPosition != 13 && oponent1.XPosition != 27) // if its in the middle
                        {
                            oponent1.CurrentDirection = "Down";
                        }
                    }
                }
                else if ((gameField[oponent1.XPosition, oponent1.YPosition + 1] != 1000) && (gameField[oponent1.XPosition, oponent1.YPosition - 1] != 1000)) // if there are empty line on both sides
                {
                    if (hero.YPosition < oponent1.YPosition && (gameField[oponent1.XPosition - 1, oponent1.YPosition + 1] != 1000) &&
                        (gameField[oponent1.XPosition - 1, oponent1.YPosition - 1] != 1000)) // if there are empty line on both sides
                    {
                        oponent1.CurrentDirection = "Up";
                    }
                    else if (hero.YPosition > oponent1.YPosition && (gameField[oponent1.XPosition - 1, oponent1.YPosition + 1] != 1000) &&
                        (gameField[oponent1.XPosition - 1, oponent1.YPosition - 1] != 1000)) // if there are empty line on both sides
                    {
                        oponent1.CurrentDirection = "Down";
                    }
                }
            }
        }

        static void DrawOponents()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(oponent1.XPosition, oponent1.YPosition);
            Console.Write(oponent1.Symbol);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(oponent2.XPosition, oponent2.YPosition);
            Console.Write(oponent2.Symbol);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(oponent3.XPosition, oponent3.YPosition);
            Console.Write(oponent3.Symbol);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(oponent4.XPosition, oponent4.YPosition);
            Console.Write(oponent4.Symbol);
            Console.ResetColor();
        }

        static void ConvertTxtToMatrix()
        {
            StreamReader reader = new StreamReader(@"..\..\Sheet.txt");
            using (reader)
            {
                for (int i = 0; i < 35; i++)
                {
                    string line = reader.ReadLine();

                    for (int j = 0; j < 59; j++)
                    {
                        if (line[j] == '*')
                        {
                            gameField[j, i] = 1000;
                        }
                        if (line[j] == '\'')
                        {
                            gameField[j, i] = 100;
                            totalPoints++;
                        }
                        if (line[j] == 'H')
                        {
                            gameField[j, i] = 72;
                        }
                    }
                }
            }
        }
        static void OponentsCollisionWithWall()
        {
            Oponent1CollisionWithWall();
            Oponent2CollisionWithWall();
            Oponent3CollisionWithWall();
            Oponent4CollisionWithWall();
        }

        private static void Oponent1CollisionWithWall()
        {
            if (gameField[oponent1.XPosition + 2, oponent1.YPosition] == 1000)
            {
                oponent1.AllowToMoveRight = false;
            }
            else
            {
                oponent1.AllowToMoveRight = true;
            }

            if (gameField[oponent1.XPosition - 2, oponent1.YPosition] == 1000)
            {
                oponent1.AllowToMoveLeft = false;
            }
            else
            {
                oponent1.AllowToMoveLeft = true;
            }
            //if (gameField[oponent1.XPosition + 1, oponent1.YPosition] == 1000)
            //{
            //    oponent1.MoveLeft();
            //}
            //if (gameField[oponent1.XPosition - 1, oponent1.YPosition] == 1000)
            //{
            //    oponent1.MoveRight();
            //}
            if (gameField[oponent1.XPosition, oponent1.YPosition + 1] == 1000
                || gameField[oponent1.XPosition - 1, oponent1.YPosition + 1] == 1000
                || gameField[oponent1.XPosition + 1, oponent1.YPosition + 1] == 1000)
            {
                oponent1.AllowToMoveDown = false;
            }
            else
            {
                oponent1.AllowToMoveDown = true;
            }
            if (gameField[oponent1.XPosition, oponent1.YPosition - 1] == 1000
                || gameField[oponent1.XPosition - 1, oponent1.YPosition - 1] == 1000
                || gameField[oponent1.XPosition + 1, oponent1.YPosition - 1] == 1000)
            {
                oponent1.AllowToMoveUp = false;
            }
            else
            {
                oponent1.AllowToMoveUp = true;
            }
        }

        private static void Oponent2CollisionWithWall()
        {
            if (gameField[oponent2.XPosition + 2, oponent2.YPosition] == 1000)
            {
                oponent2.AllowToMoveRight = false;
            }
            else
            {
                oponent2.AllowToMoveRight = true;
            }

            if (gameField[oponent2.XPosition - 2, oponent2.YPosition] == 1000)
            {
                oponent2.AllowToMoveLeft = false;
            }
            else
            {
                oponent2.AllowToMoveLeft = true;
            }
            //if (gameField[oponent2.XPosition + 1, oponent2.YPosition] == 1000)
            //{
            //    oponent2.MoveLeft();
            //}
            //if (gameField[oponent2.XPosition - 1, oponent2.YPosition] == 1000)
            //{
            //    oponent2.MoveRight();
            //}
            if (gameField[oponent2.XPosition, oponent2.YPosition + 1] == 1000
                || gameField[oponent2.XPosition - 1, oponent2.YPosition + 1] == 1000
                || gameField[oponent2.XPosition + 1, oponent2.YPosition + 1] == 1000)
            {
                oponent2.AllowToMoveDown = false;
            }
            else
            {
                oponent2.AllowToMoveDown = true;
            }
            if (gameField[oponent2.XPosition, oponent2.YPosition - 1] == 1000
                || gameField[oponent2.XPosition - 1, oponent2.YPosition - 1] == 1000
                || gameField[oponent2.XPosition + 1, oponent2.YPosition - 1] == 1000)
            {
                oponent2.AllowToMoveUp = false;
            }
            else
            {
                oponent2.AllowToMoveUp = true;
            }
        }

        private static void Oponent3CollisionWithWall()
        {
            if (gameField[oponent3.XPosition + 2, oponent3.YPosition] == 1000)
            {
                oponent3.AllowToMoveRight = false;
            }
            else
            {
                oponent3.AllowToMoveRight = true;
            }

            if (gameField[oponent3.XPosition - 2, oponent3.YPosition] == 1000)
            {
                oponent3.AllowToMoveLeft = false;
            }
            else
            {
                oponent3.AllowToMoveLeft = true;
            }
            //if (gameField[oponent3.XPosition + 1, oponent3.YPosition] == 1000)
            //{
            //    oponent3.MoveLeft();
            //}
            //if (gameField[oponent3.XPosition - 1, oponent3.YPosition] == 1000)
            //{
            //    oponent3.MoveRight();
            //}
            if (gameField[oponent3.XPosition, oponent3.YPosition + 1] == 1000
                || gameField[oponent3.XPosition - 1, oponent3.YPosition + 1] == 1000
                || gameField[oponent3.XPosition + 1, oponent3.YPosition + 1] == 1000)
            {
                oponent3.AllowToMoveDown = false;
            }
            else
            {
                oponent3.AllowToMoveDown = true;
            }
            if (gameField[oponent3.XPosition, oponent3.YPosition - 1] == 1000
                || gameField[oponent3.XPosition - 1, oponent3.YPosition - 1] == 1000
                || gameField[oponent3.XPosition + 1, oponent3.YPosition - 1] == 1000)
            {
                oponent3.AllowToMoveUp = false;
            }
            else
            {
                oponent3.AllowToMoveUp = true;
            }
        }

        private static void Oponent4CollisionWithWall()
        {
            if (gameField[oponent4.XPosition + 2, oponent4.YPosition] == 1000)
            {
                oponent4.AllowToMoveRight = false;
            }
            else
            {
                oponent4.AllowToMoveRight = true;
            }

            if (gameField[oponent4.XPosition - 2, oponent4.YPosition] == 1000)
            {
                oponent4.AllowToMoveLeft = false;
            }
            else
            {
                oponent4.AllowToMoveLeft = true;
            }
            //if (gameField[oponent4.XPosition + 1, oponent4.YPosition] == 1000)
            //{
            //    oponent4.MoveLeft();
            //}
            //if (gameField[oponent4.XPosition - 1, oponent4.YPosition] == 1000)
            //{
            //    oponent4.MoveRight();
            //}
            if (gameField[oponent4.XPosition, oponent4.YPosition + 1] == 1000
                || gameField[oponent4.XPosition - 1, oponent4.YPosition + 1] == 1000
                || gameField[oponent4.XPosition + 1, oponent4.YPosition + 1] == 1000)
            {
                oponent4.AllowToMoveDown = false;
            }
            else
            {
                oponent4.AllowToMoveDown = true;
            }
            if (gameField[oponent4.XPosition, oponent4.YPosition - 1] == 1000
                || gameField[oponent4.XPosition - 1, oponent4.YPosition - 1] == 1000
                || gameField[oponent4.XPosition + 1, oponent4.YPosition - 1] == 1000)
            {
                oponent4.AllowToMoveUp = false;
            }
            else
            {
                oponent4.AllowToMoveUp = true;
            }
        }

        static void PlayerCollisionWithWall()
        {
            if (gameField[hero.XPosition + 2, hero.YPosition] == 1000)
            {
                hero.AllowToMoveRight = false;
            }
            else
            {
                hero.AllowToMoveRight = true;
            }
            if (gameField[hero.XPosition - 2, hero.YPosition] == 1000)
            {
                hero.AllowToMoveLeft = false;
            }
            else
            {
                hero.AllowToMoveLeft = true;
            }
            //if (gameField[hero.XPosition + 1, hero.YPosition] == 1000)
            //{
            //    hero.MoveLeft();
            //}
            //if (gameField[hero.XPosition - 1, hero.YPosition] == 1000)
            //{
            //    hero.MoveRight();
            //}
            if (gameField[hero.XPosition, hero.YPosition + 1] == 1000
                || gameField[hero.XPosition - 1, hero.YPosition + 1] == 1000
                || gameField[hero.XPosition + 1, hero.YPosition + 1] == 1000)
            {
                hero.AllowToMoveDown = false;
            }
            else
            {
                hero.AllowToMoveDown = true;
            }
            if (gameField[hero.XPosition, hero.YPosition - 1] == 1000
                || gameField[hero.XPosition - 1, hero.YPosition - 1] == 1000
                || gameField[hero.XPosition + 1, hero.YPosition - 1] == 1000)
            {
                hero.AllowToMoveUp = false;
            }
            else
            {
                hero.AllowToMoveUp = true;
            }
        }

        private static void RenderFields()
        {
            try
            {
                ConvertTxtToMatrix();
            }
            catch (FileNotFoundException)
            {
                Console.SetCursorPosition(7, 20);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Фатална грешка файлът Sheet.txt не е намерен!");
                Console.SetCursorPosition(14, 22);
                Console.WriteLine("Натиснете клавиш за изход!");
                Console.ReadKey();
                Console.ResetColor();
                Environment.Exit(0);
            }
            

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int row = 0; row < 35; row++)
            {
                for (int col = 0; col < 59; col++)
                {
                    if (gameField[col, row] == 1000)
                    {
                        Console.Write("*");
                    }
                    else if (gameField[col, row] == 100)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("'");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (gameField[col, row] == 72)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("H");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
            Console.ResetColor();
        }

        static void DrawPlayer()
        {
            Console.ForegroundColor = hero.Color;
            Console.SetCursorPosition(hero.XPosition, hero.YPosition);
            Console.Write(hero.Symbol);
            Console.ResetColor();
        }
    }
}


/*Player:
 * 1.Lives
 * 2. X and Y coordinate
 * 3. Score
*/
/*Field:
 *1 for dots.
 *2 for walls
 *3 for bonuses
*/
/*Enemies:
 *1. X and Y coordinate
 *2. artificial intelligence
 *3. disoriented when player get the bonus.
 */