using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Round
    {
        private int _radius;
        private int _x;
        private int _y;

        public Round(int radius, int x, int y)
        {
            _radius = Radius;
            _x = X;
            _y = Y;
        }

        public Round(int radius, int x, int y)
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
}
