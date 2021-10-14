using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Round : Circle
    {
        public Round(int x, int y, int radius)
            : base(x, y, radius)
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
}
