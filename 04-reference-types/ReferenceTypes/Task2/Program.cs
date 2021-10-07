using System;

namespace Task2
{
    class Round
    {
        protected int _radius;
        protected int _x;
        protected int _y;

        public Round (int radius, int x, int y)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException($"{nameof(radius)} Радиус не может быть отрицательным");
            _radius = radius;
            _x = x;
            _y = y;
        }

        public int Radius
        {
            get => _radius;
        }

        public int X
        {
            get => _x;
        }

        public int Y
        {
            get => _y;
        }

        public double Circumference
        {
            get => 2 * Math.PI * _radius;
        }

        public double Area
        {
            get => Math.PI * _radius * _radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round(5, 0, 0);
            Console.WriteLine(round.Area);
            Console.WriteLine(round.Circumference);
        }
    }
}
