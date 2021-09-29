using System;

namespace Task3
{
    class Triangle
    {
        int _a;
        int _b;
        int _c;

        public Triangle (int a, int b, int c)
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
            double p = (_a + _b + _c) / 2.0;
            double area = Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            return Math.Round(area, 2);
        }

        public int GetPerimeter() => _a + _b + _c;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 5, 7);
            Console.WriteLine(triangle.GetArea());
            Console.WriteLine(triangle.GetPerimeter());
        }
    }
}
