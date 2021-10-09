using System;

namespace Task1
{
    abstract class Figure
    {
        protected int _x;
        protected int _y;

        public Figure(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get => _x;
        }

        public int Y
        {
            get => _y;
        }

        public abstract void Draw();
    }

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

    class Rectangle : Figure
    {
        private int _length;
        private int _width;

        public Rectangle (int x, int y, int length, int width)
            :base(x, y)
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

    class Round : Circle
    {
        public Round(int x, int y, int radius)
            :base(x, y, radius)
        {

        }

        public virtual double Area
        {
            get => Math.PI * _radius * _radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Тип фигуры: круг");
            Console.WriteLine("X = " + _x);
            Console.WriteLine("Y = " + _y);
            Console.WriteLine("Радиус = " + _radius);
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            Figure[] arrayFigures = new Figure[5];
            Line line = new Line(5, 10, 15);
            Circle circle = new Circle(2, 3, 8);
            Rectangle rectangle = new Rectangle(2, 5, 16, 4);
            Round round = new Round(-4, 4, 16);
            Ring ring = new Ring(0, 0, 60, 40);

            arrayFigures[0] = line;
            arrayFigures[1] = circle;
            arrayFigures[2] = rectangle;
            arrayFigures[3] = round;
            arrayFigures[4] = ring;

            foreach (Figure figure in arrayFigures)
            {
                figure.Draw();
            }
        }
    }
}
