using System;

namespace Task4
{
    
    class Program
    {
        static void Main(string[] args)
        {

            int a = 1;
            int b = 2;
            int c = 5;

            string rez;

            if (!((a + b > c) & (b + c > a) & (a + c) > b))
            {
                throw new ArgumentOutOfRangeException($" Некорректный ввод - треугольник с такими сторонами не существует");
            }

        }
    }
}
