using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(-1, -1, -1);
            Console.WriteLine(triangle.GetArea());
            Console.WriteLine(triangle.GetPerimeter());
        }
    }
}
