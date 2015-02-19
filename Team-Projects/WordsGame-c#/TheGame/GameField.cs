using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class GameField
    {
        private int x;
        private int y;
        public char[,] Border;

        public int Y
        {
            get { return y; }
            set 
            {
                if (value < 9)
                {
                    throw new ArgumentException("Game Field coordinates must be bigger");
                }
                y = value; 
            }
        }

        public int X
        {
            get { return x; }
            set 
            {
                if (value < 9)
                {
                    throw new ArgumentException("Game Field coordinates must be bigger");
                }
                x = value; 
            }
        }


        public GameField(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Border = new char[this.X, this.Y];
            InitializeBorder();
        }

        private void InitializeBorder()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            for (int row = 0; row < Border.GetLength(0); row++)
            {
                Border[row, 0] = '═';
                Border[row, Border.GetLength(1) - 1] = '═';
            }
            for (int col = 0; col < Border.GetLength(1); col++)
            {
                Border[0, col] = '│';
                Border[Border.GetLength(0) - 1, col] = '│';
            }
            Border[0, 0] = '╒';
            Border[Border.GetLength(0) - 1, 0] = '╕';
            Border[0, Border.GetLength(1) - 1] = '╘';
            Border[Border.GetLength(0) - 1, Border.GetLength(1) - 1] = '╛'; 
            
        }

        public static void Field()
        {
            var lives = 0;
            var speed = 0;
            var score = 0;
            var comboScore = 6;
            string line = new string('-', 60);
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 60;

            Set("Lives", lives, 5, 2);
            Set("Speed", speed, 5, 3);
            Set("Score", score, 40, 3);
            if (comboScore % 3 == 0)
            {
                int n = comboScore / 3;
                char nn = Convert.ToChar(n);
                string combo = "Combo" + n + 'x';
                SetCombo(combo, 41, 2);
            }
            Console.ForegroundColor = ConsoleColor.White;
            SetTwo(line, 0, 5);
            SetTwo(line, 0, 24);
            Console.Read();

        }

        public static void Set(string s, int number, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}: {1}", s, number);
        }

        public static void SetTwo(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("{0}", s);
        }

        public static void SetCombo(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s);
        }
    }
}
