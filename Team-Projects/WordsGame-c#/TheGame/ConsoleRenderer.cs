using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TheGame
{
    class ConsoleRenderer
    {
        private GameField GameField { get; set; }
        private int oldX;
        private int oldY;
        public static int inputBoxLenght = 16;

        public ConsoleRenderer(GameField gameField)
        {
            this.GameField = gameField;
            oldX = gameField.X;
            oldY = gameField.Y;
        }

        public void PrintBox(ConsoleColor color)
        {
            string breckets = "││";
            Console.ForegroundColor = color;
            Console.SetCursorPosition(BrainGame.worldCols / 2 - (inputBoxLenght / 2) - 1, BrainGame.worldRows);
            Console.Write('╒');
            Console.SetCursorPosition(BrainGame.worldCols / 2 - (inputBoxLenght / 2), BrainGame.worldRows);
            Console.Write(new string('═', inputBoxLenght));
            Console.Write('╕');

            //for (int i = 0; i < 15; i++)
            //{
            //    Console.Write('═');
            //}

            Console.SetCursorPosition(BrainGame.worldCols / 2 - (inputBoxLenght/2) - 1 , BrainGame.worldRows + 1);
            Console.Write(breckets[0]);
            Console.WriteLine("                    ");
            Console.SetCursorPosition(BrainGame.worldCols / 2 + (inputBoxLenght / 2), BrainGame.worldRows + 1);
            Console.Write(breckets[1]);
            Console.SetCursorPosition(BrainGame.worldCols / 2 - (inputBoxLenght / 2) - 1, BrainGame.worldRows + 2);
            Console.Write('╘');
            Console.SetCursorPosition(BrainGame.worldCols / 2 - (inputBoxLenght / 2), BrainGame.worldRows + 2);
            Console.Write(new string('═', inputBoxLenght));
            //for (int i = 0; i < 15; i++)
            //{
            //    Console.Write('═');
            //} 
            Console.Write('╛');
            //Border[0, 0] = '╒';
            //Border[Border.GetLength(0) - 1, 0] = '╕';
            //Border[0, Border.GetLength(1) - 1] = '╘';
            //Border[Border.GetLength(0) - 1, Border.GetLength(1) - 1] = '╛'; 

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void DrawMatrix(ConsoleColor color)
        {
            for (int row = 0; row < GameField.Border.GetLength(0); row++)
            {
                for (int col = 0; col < GameField.Border.GetLength(1); col++)
                {
                    Console.ForegroundColor = color;
                    Console.SetCursorPosition(row, col);
                    Console.WriteLine(GameField.Border[row, col]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public void Draw(int x, int y, string word, ConsoleColor color)
        {
            if ((x < 0 || y < 0 || x > GameField.X || y > GameField.Y) ||
                (x + word.Length) > GameField.X)
            {
                throw new IndexOutOfRangeException("Coordinates must be in the Game Field range");
            }
            Console.ForegroundColor = color;
            Console.SetCursorPosition(oldX, oldY);
            for (int i = 0; i < word.Length + 2; i++)
            {
                Console.Write(" ");                
            }
            Console.SetCursorPosition(x, y);
            Console.Write(word);
            Console.ForegroundColor = ConsoleColor.Gray;
            oldX = x;
            oldY = y;
        }
    }
}
