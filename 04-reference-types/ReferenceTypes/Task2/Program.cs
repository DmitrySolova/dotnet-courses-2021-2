using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round(5, 0, 0);
            Console.WriteLine(round.Area);
            Console.WriteLine(round.Circumference);
        }
    }
}
