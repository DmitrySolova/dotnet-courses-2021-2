using System;
using System.Collections.Generic;
using System.Text;

namespace Task1 {
    class Rectangle : Figure
    {
        private int _length;
        private int _width;

        public Rectangle(int x, int y, int length, int width)
            : base(x, y)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException($"{nameof(_length)} Длина не может быть отрицательной или равной 0");
            if (width <= 0) throw new ArgumentOutOfRangeException($"{nameof(_width)} Ширина не может быть отрицательной или равной 0");
            _length = length;
            _width = width;
        }

        public double Length
        {
            get => _length;
        }

        public double Width
        {
            get => _width;
        }

        public int Area
        {
            get => _length * _width;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: прямоугольник");
            Console.WriteLine("X = " + _x);
            Console.WriteLine("Y = " + _y);
            Console.WriteLine("Длина = " + _length);
            Console.WriteLine("Ширина = " + _width);
        }
    }
}
