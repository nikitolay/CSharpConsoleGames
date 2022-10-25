using Snake.GameObjects;
using SnakeGame.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Core
{
    public class Engine
    {
        private Direction direction;
        private readonly Snnake snake;
        private readonly Wall wall;
        private readonly Point[] pointsOfDirection;
        private double sleepTime;

        public Engine(Snnake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;
            this.pointsOfDirection = new Point[4];
            this.direction = Direction.Right;
            this.sleepTime = 100;
        }

        public void Run()
        {
            this.CreateDirections();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isaMoving = this.snake.TryMove(this.pointsOfDirection[(int)direction]);

                if (!isaMoving)
                {
                    AskUserFoRestart();
                }
                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);
            }
        }

        private void AskUserFoRestart()
        {
            int leftX = this.wall.LeftX + 2;
            int topY = 3;
            Console.SetCursorPosition(leftX, topY);
            Console.Write(@"GAME OVER!");
            Console.SetCursorPosition(leftX, topY + 1);
            Console.Write(@"TRY AGAING? ");
            Console.SetCursorPosition(leftX, topY + 2);
            Console.Write(@"PRESS 'ENTER' TO START");

            var choose = Console.ReadKey();
            if (choose.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                Environment.Exit(0);
            }

        }

        private void CreateDirections()
        {
            this.pointsOfDirection[0] = new Point(1, 0);
            this.pointsOfDirection[1] = new Point(-1, 0);
            this.pointsOfDirection[2] = new Point(0, 1);
            this.pointsOfDirection[3] = new Point(0, -1);
        }


        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();


            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }




        }
    }
}
