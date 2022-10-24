using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char HASH_SYMBOL = '#';
        private const int POINTS = 3;
        public FoodHash(Wall wall) 
            : base(wall, HASH_SYMBOL, POINTS)
        {
        }
    }
}
