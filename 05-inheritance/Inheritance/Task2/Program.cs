using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round ring = new Ring(9, 8, 0, 0);
            Console.WriteLine(ring.Area);
            Console.WriteLine(ring.Circumference);
        }
    }
}
