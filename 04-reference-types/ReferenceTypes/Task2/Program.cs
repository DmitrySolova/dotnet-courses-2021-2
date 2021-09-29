using System;

namespace Task2
{
    class Round
    {
        int _radius;
        int _x;
        int _y;
        double _circumference;
        double _area;

        public Round (int radius, int x, int y)
        {
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
            get => Math.Round(2 * Math.PI * _radius, 2);
        }

        public double Area
        {
            get => Math.Round(Math.PI * _radius * _radius, 2);
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
