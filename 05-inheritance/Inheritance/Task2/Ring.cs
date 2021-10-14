using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Ring : Round
    {
        private int _innerRadius;

        public Ring(int radius, int innerRadius, int x, int y)
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
}
