using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    public class Point
    {
		private int leftX;
		private int topY;

		public Point(int leftX, int topY)
		{
			LeftX = leftX;
			TopY = topY;
		}

		public int LeftX
		{
			get { return leftX; }
			set { leftX = value; }
		}

		public int TopY
		{
			get { return topY; }
			set { topY = value; }
		}


		public void Draw(char symbol)
		{
			Console.SetCursorPosition(leftX,TopY);
			Console.Write(symbol);
		}

		public void Draw(int left,int top,char symbol)
		{
			Console.SetCursorPosition(left, top);
			Console.Write(symbol);
		}

	}
}
