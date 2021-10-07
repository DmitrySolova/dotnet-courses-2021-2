using System;

namespace Task2
{
    class Round
    {
        protected int _radius;
        protected int _x;
        protected int _y;

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

        public virtual double Circumference
        {
            get => 2 * Math.PI * _radius;
        }

        public virtual double Area
        {
            get => Math.PI * _radius * _radius;
        }
    }

    class Ring : Round
    {
        private int _innerRadius;

        public Ring (int radius, int innerRadius, int x, int y)
            : base(radius, x, y)
        {
            if (innerRadius <= 0) throw new ArgumentOutOfRangeException($"{nameof(innerRadius)} Внутренний радиус не может быть отрицательным");
            if (innerRadius >= radius) throw new ArgumentOutOfRangeException($"{nameof(innerRadius)} Внутренний радиус не может быть больше внутреннего");
            _innerRadius = innerRadius;
        }

        public int InnerRadius
        {
            get => _innerRadius;
        }
        public override double Circumference
        {
            get => 2 * Math.PI * _radius + 2 * Math.PI * _innerRadius;
        }

        public override double Area
        {
            get => Math.PI * _radius * _radius - Math.PI * (_innerRadius * _innerRadius);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Round ring = new Ring(9, 8, 0, 0);
            Console.WriteLine(ring.Area);
            Console.WriteLine(ring.Circumference);
        }
    }
}
