using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Строки сторон, которые будем проверять на наличие корректного ввода

            string inputA = "";
            string inputB = "";

            // Числа сторон и площади, с которыми будем работать

            int parsedA;
            int parsedB;
            int square;

            // Переменная-флаг, показывающий что ввод значения корректен

            bool incorrectInput = true;

            // Сообщение о некорректном значении ввода

            string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

            Console.WriteLine("Привет! Эта программа для расчета площади прямоугольника со сторонами A и B");
            Console.WriteLine("ВНИМАНИЕ! Нельзя вводить некорректные значения сторон: 0, отрицательные или нецелые числа, строки");

            do
            {
                Console.Write("Ввведи сторону A: ");
                inputA = Console.ReadLine();

                if (int.TryParse(inputA, out parsedA) == false)
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

            do
            {
                Console.Write("Ввведи сторону B: ");
                inputB = Console.ReadLine();

                if (int.TryParse(inputB, out parsedB) == false)
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
                        square = parsedA * parsedB;
                        Console.WriteLine(square);
                        incorrectInput = false;
                    }
                }
            } while (incorrectInput);

        }
    }
}
