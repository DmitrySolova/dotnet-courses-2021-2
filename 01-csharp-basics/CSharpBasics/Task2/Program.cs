using System;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Привет! Эта программа для отрисовки половинки елочки");
			Console.WriteLine("Число N - это количество строк в елочке и количество символов в ней");
			Console.WriteLine("ВНИМАНИЕ! Нельзя вводить некорректные значения N: 0, отрицательные или нецелые числа, строки");

            int parsedN;

            bool incorrectInput = false;

            string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

            do
            {
                Console.Write("Ввведи число N: ");
                string inputN = Console.ReadLine();

                if (!int.TryParse(inputN, out parsedN))
                {
                    incorrectInput = true;
                }
                else
                {
                    if (parsedN <= 0)
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

            string result = "";

            for (int i = 0; i < parsedN; i++)
            {
                result += "*";
                Console.WriteLine(result);
            }
        }
	}
}
