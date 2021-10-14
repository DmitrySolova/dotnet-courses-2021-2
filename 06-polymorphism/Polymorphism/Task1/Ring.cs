using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Ring : Round
    {
        private int _innerRadius;

        public Ring(int x, int y, int radius, int innerRadius)
            : base(x, y, radius)
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

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: кольцо");
            Console.WriteLine("X = " + _x);
            Console.WriteLine("Y = " + _y);
            Console.WriteLine("Радиус = " + _radius);
            Console.WriteLine("Внутренний радиус = " + _innerRadius);
        }
    }
}
