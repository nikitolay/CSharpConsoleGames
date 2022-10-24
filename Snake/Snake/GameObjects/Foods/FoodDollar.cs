using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char DOLLAR_SYMBOL = '$';
        private const int POINTS = 2;
        public FoodDollar(Wall wall)
            : base(wall, DOLLAR_SYMBOL, POINTS)
        {
        }
    }
}
