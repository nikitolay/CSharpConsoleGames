using Snake.GameObjects.Foods;
namespace Snake.GameObjects
{
    public class Snnake 
    {
        private const char SYMBOL = '\u25CF';
        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;

        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;
        public Snnake(Wall wall) 
        {
             this.wall = wall;
            this.snakeElements=new Queue<Point>();
              this.foods = new Food[3];
            this.foodIndex = this.RandomFoodIndex;
            GetFoods();
            CreateSnake();
        }

        

        public int RandomFoodIndex => new  Random().Next(0, foods.Length);
        public void CreateSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                this.snakeElements.Enqueue(new Point(leftX, 2));
            }
            this.foods[this.foodIndex].SetRandomPosition(snakeElements);
        }
        public bool TryMove(Point direction)
        {
            Point snakeHead = this.snakeElements.Last();

            this.NextSnakePoint(direction,snakeHead);

            bool isPointOfSnake = this.snakeElements.Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);
            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead=new Point(this.nextLeftX, this.nextTopY);

            if (wall.isPointoWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(SYMBOL);

            if (this.foods[this.foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeHead);
            }

            Point snakeTail =this.snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        private void Eat(Point direction, Point snakeHead)
        {
           int lenghtFoodPoints = this.foods[this.foodIndex].FoodPoints;

            for (int i = 0; i < lenghtFoodPoints; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.NextSnakePoint(direction, snakeHead);
            }

            this.wall.AddPoints(this.snakeElements);
            this.wall.PlayerInfo();

            this.foodIndex = this.RandomFoodIndex;
            this.foods[foodIndex].SetRandomPosition(snakeElements);

        }

        private void NextSnakePoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY=snakeHead.TopY + direction.TopY;
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodAsterik(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodHash(this.wall);
        }
    }
}
