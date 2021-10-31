using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
			TwoDPoint point1 = new TwoDPoint(1, 1);
			TwoDPoint point2 = new TwoDPoint(10, 10);

			Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", point1.GetHashCode(), point2.GetHashCode());

			TwoDPointWithHash newPoint1 = new TwoDPointWithHash(1, 1);
			TwoDPointWithHash newPoint2 = new TwoDPointWithHash(10, 10);

			Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", newPoint1.GetHashCode(), newPoint2.GetHashCode());
		}
    }
}
