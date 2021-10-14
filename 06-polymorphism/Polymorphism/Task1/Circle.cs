using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Circle : Figure
    {
        protected int _radius;
        public Circle(int x, int y, int radius)
            : base(x, y)
        {
            if (radius <= 0) throw new ArgumentOutOfRangeException($"{nameof(radius)} Радиус не может быть отрицательным");
            _radius = radius;
        }

        public int Radius
        {
            get => _radius;
        }

        public virtual double Circumference
        {
            get => 2 * Math.PI * _radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: окружность");
            Console.WriteLine("X = " + _x);
            Console.WriteLine("Y = " + _y);
            Console.WriteLine("Радиус = " + _radius);
        }
    }
}
