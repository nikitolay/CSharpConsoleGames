using Snake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    public class Snake : Point
    {
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;
        public Snake(int leftX, int topY) 
            : base(leftX, topY)
        {
            GetFoods();
        }


        public int RandomFoodIndex => new  Random().Next(0, foods.Length);
        public void CreateSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                this.snakeElements.Enqueue(new Point(2, leftX));
            }
        }
        public bool TryMove(Point direction)
        {
            var snakeHead = this.snakeElements.Last();

        }
        private void GetFoods()
        {
            this.foods[0] = new FoodAsterik(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
        }
    }
}
