using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char symbol;
        public Food(Wall wall, char symbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.symbol = symbol;
            this.FoodPoints = points;
        }

        private void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            bool isPointOfSnake = IsPointOfSnake(snakeElements);
            while (isPointOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);
                isPointOfSnake = IsPointOfSnake(snakeElements);
            }

            this.Draw(this.LeftX, this.TopY, symbol);
        }

        private bool IsPointOfSnake(Queue<Point> snakeElements)
        {
            return snakeElements.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
        }

        public int FoodPoints { get; set; }


    }
}
