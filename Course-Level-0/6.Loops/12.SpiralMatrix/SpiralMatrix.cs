using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.SpiralMatrix
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int rightBottomBorder = num;
            int topLeftBorder = -1;
            string direction = "right";
            int row = 0;
            int col = 0;
            int[,] matrix = new int[num, num];

            for (int i = 1; i <= num * num; i++)
            {
                if (direction == "right")
                {
                    matrix[row, col] = i;
                    col++;

                    if (col == rightBottomBorder)
                    {
                        direction = "down";
                        col--;
                        row++;
                        continue;
                    }
                }
                if (direction == "down")
                {
                    matrix[row, col] = i;
                    row++;

                    if (row == rightBottomBorder)
                    {
                        direction = "left";
                        row--;
                        col--;
                        rightBottomBorder--;
                        continue;
                    }
                }
                if (direction == "left")
                {
                    matrix[row, col] = i;
                    col--;

                    if (col == topLeftBorder)
                    {
                        col++;
                        row--;
                        topLeftBorder++;
                        direction = "up";
                        continue;
                    }
                }
                if (direction == "up")
                {
                    matrix[row, col] = i;
                    row--;

                    if (row == topLeftBorder)
                    {
                        direction = "right";
                        row++;
                        col++;
                        continue;
                    }
                }
            }

            for (int rows = 0; rows < num; rows++)
            {
                for (int cols = 0; cols < num; cols++)
                {
                    Console.Write("{0,-3}", matrix[rows, cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
