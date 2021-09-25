using System;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{

            // Строка, которую будем парсить на проверку правильности ввода N

            string inputN;

            // Количество строк и символов

            int parsedN;

            // Переменная-флаг, показывающий что ввод значения корректен

            bool incorrectInput = false;

            // Сообщение о некорректном значении ввода

            string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

            // Строка, которая должна вывести необходимое количество символов в зависимости от числа N

            string result = "";

            Console.WriteLine("Привет! Эта программа для отрисовки половинки елочки");
			Console.WriteLine("Число N - это количество строк в елочке и количество символов в ней");
			Console.WriteLine("ВНИМАНИЕ! Нельзя вводить некорректные значения N: 0, отрицательные или нецелые числа, строки");

            do
            {
                Console.Write("Ввведи число N: ");
                inputN = Console.ReadLine();

                if (int.TryParse(inputN, out parsedN) == false)
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
                        for (int i = 0; i < parsedN; i++)
						{
                            result += "*";
                            Console.WriteLine(result);
                        }
                    }
                }
            } while (incorrectInput);
        }
	}
}
