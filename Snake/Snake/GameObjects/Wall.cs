using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    public class Wall : Point
    {
        private const char WALL_SYMBOL = '\u25A0';

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {

            InitializeBorders(leftX, topY);
            PlayerInfo();
        }

        public int FoodPoints { get; private set; }

        private void InitializeBorders(int leftX, int topY)
        {
            SetVerticalBorder(0);
            SetVerticalBorder(leftX);
            SetHorizontalBorder(0);
            SetHorizontalBorder(topY);
        }

        private void SetHorizontalBorder(int topY)
        {
            for (int leftX = 0; leftX <= this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        private void SetVerticalBorder(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, WALL_SYMBOL);
            }
        }
        public void AddPoints(Queue<Point> snakeElements)
        {
            this.FoodPoints = snakeElements.Count - 6;
        }

        public void PlayerInfo()
        {
            Console.SetCursorPosition(this.LeftX+3, 0);
            Console.WriteLine($"Points: {FoodPoints}");
            Console.SetCursorPosition(this.LeftX+3, 1);
            Console.Write($"Player leves is: {FoodPoints / 10}");

        }
    }
}
