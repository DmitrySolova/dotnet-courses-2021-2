using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool incorrectInput = true;

            string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

            Console.WriteLine("Привет! Эта программа для расчета площади прямоугольника со сторонами A и B");
            Console.WriteLine("ВНИМАНИЕ! Нельзя вводить некорректные значения сторон: 0, отрицательные или нецелые числа, строки");

            int parsedA;

            do
            {
                Console.Write("Ввведи сторону A: ");
                string inputA = Console.ReadLine();

                if (!int.TryParse(inputA, out parsedA))
                {
                    incorrectInput = true;
                }
                else
                {
                    if (parsedA <= 0)
                    {
                        Console.WriteLine(wrongInputMassage);
                        incorrectInput = true;
                    }
                    else
					{
                        incorrectInput = false;
                    }
                }
            } while (incorrectInput);

            int parsedB;

            do
            {
                Console.Write("Ввведи сторону B: ");
                string inputB = Console.ReadLine();

                if (!int.TryParse(inputB, out parsedB))
                {
                    incorrectInput = true;
                }
                else
                {
                    if (parsedB <= 0)
                    {
                        Console.WriteLine(wrongInputMassage);
                        incorrectInput = true;
                    }
                    else
					{
                        incorrectInput = false;
                    }
                }
            } while (incorrectInput);

            int square = parsedA * parsedB;
            Console.WriteLine(square);

        }
    }
}
