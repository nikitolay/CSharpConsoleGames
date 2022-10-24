using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects.Foods
{
    public class FoodAsterik : Food
    {
        private const char ASTERIK_SYMBOL = '*';
        private const int POINTS = 1;
        public FoodAsterik(Wall wall) 
            : base(wall, ASTERIK_SYMBOL,POINTS)
        {
        }
    }
}
