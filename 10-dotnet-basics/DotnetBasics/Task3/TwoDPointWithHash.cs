using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
	class TwoDPointWithHash : TwoDPoint
	{
		public TwoDPointWithHash(int x, int y) : base(x, y)
		{ }

		public override int GetHashCode()
		{
			return Tuple.Create(x, y).GetHashCode(); // ^ выполняет операцию логического исключающего XOR побитно

			// в чем тут проблема?
		}
	}
}
