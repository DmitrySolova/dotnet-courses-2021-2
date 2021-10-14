using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Triangle
    {
        private int _a;
        private int _b;
        private int _c;

        public Triangle(int a, int b, int c)
        {

            if (!((a + b >= c) & (b + c >= a) & (a + c) >= b))
            {
                throw new ArgumentOutOfRangeException($" Некорректный ввод - треугольник с такими сторонами не существует");
            }
            _a = a;
            _b = b;
            _c = c;
        }

        public int A
        {
            get => _a;
        }
        public int B
        {
            get => _b;
        }
        public int C
        {
            get => _c;
        }

        public double GetArea()
        {
            double halfPerimeter = (_a + _b + _c) / 2.0;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - _a) * (halfPerimeter - _b) * (halfPerimeter - _c));
            return area;
        }

        public int GetPerimeter() => _a + _b + _c;
    }
}
