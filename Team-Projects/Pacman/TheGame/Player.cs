using System;
namespace TheGame
{
    public class Player
    {
        private int xPosition;
        private int yPosition;
        private char symbol;
        private bool allowToMoveDown;
        private bool allowToMoveUp;
        private bool allowToMoveRight;
        private bool allowToMoveLeft;
        private string currentDirection;
        private string currentLocation;
        private ConsoleColor color;

        public ConsoleColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public string CurrentLocation
        {
            get
            {
                if (yPosition > Console.WindowHeight / 2 && xPosition < Console.WindowWidth / 2)
                {
                    return this.currentLocation = "DownLeft";
                }
                else if (yPosition < Console.WindowHeight / 2 && xPosition < Console.WindowWidth / 2)
                {
                    return this.currentLocation = "UpLeft";
                }
                else if (yPosition > Console.WindowHeight / 2 && xPosition > Console.WindowWidth / 2)
                {
                    return this.currentLocation = "DownRight";
                }
                else
                {
                    return this.currentLocation = "UpRight";
                }
            }
            set { this.currentLocation = value; }
        }
        public string CurrentDirection
        {
            get { return this.currentDirection; }
            set { this.currentDirection = value; }
        }
        public bool AllowToMoveDown
        {
            get { return this.allowToMoveDown; }
            set { this.allowToMoveDown = value; }
        }
        public bool AllowToMoveUp
        {
            get { return this.allowToMoveUp; }
            set { this.allowToMoveUp = value; }
        }
        public bool AllowToMoveRight
        {
            get { return this.allowToMoveRight; }
            set { this.allowToMoveRight = value; }
        }
        public bool AllowToMoveLeft
        {
            get { return this.allowToMoveLeft; }
            set { this.allowToMoveLeft = value; }
        }
        public int XPosition
        {
            get { return this.xPosition; }
            set { this.xPosition = value; }

        }
        public int YPosition
        {
            get { return this.yPosition; }
            set { this.yPosition = value; }
        }
        public char Symbol
        {
            get { return this.symbol; }
            set { this.symbol = value; }
        }
        public void HoldOn()//calling when miss oponents movement
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xPosition, yPosition);
            Console.Write(symbol);
            Console.ResetColor();
        }
        public void MoveRight()
        {
            if (xPosition < Console.WindowWidth - 1)
            {
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(' ');
                xPosition++;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(symbol);
                Console.ResetColor();
            }
        }
        public void MoveLeft()
        {
            if (xPosition > 0)
            {
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(' ');
                xPosition--;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(symbol);
                Console.ResetColor();
            }
        }
        public void MoveUp()
        {
            if (yPosition > 0)
            {
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(' ');
                yPosition--;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(symbol);
                Console.ResetColor();
            }
        }
        public void MoveDown()
        {
            if (yPosition < Console.WindowHeight - 1)
            {
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(' ');
                yPosition++;
                Console.ForegroundColor = color;
                Console.SetCursorPosition(xPosition, yPosition);
                Console.Write(symbol);
                Console.ResetColor();
            }
        }
    }
}
