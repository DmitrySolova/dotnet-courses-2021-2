using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Line : Figure
    {
        protected double _length;

        public Line(int x, int y, double lenght)
            : base(x, y)
        {
            if (lenght <= 0) throw new ArgumentOutOfRangeException($"{nameof(lenght)} Длина не может быть отрицательной или равной 0");
            _length = lenght;

        }

        public double Length
        {
            get => _length;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: линия");
            Console.WriteLine("X = " + _x);
            Console.WriteLine("Y = " + _y);
            Console.WriteLine("Длина = " + _length);
        }
    }
}
