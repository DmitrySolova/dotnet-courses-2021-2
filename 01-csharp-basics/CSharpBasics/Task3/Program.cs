using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			// Строка, которую будем парсить на проверку правильности ввода N

			string inputN;

			// Высота пирамидки

			int parsedN;

			// Переменная-флаг, показывающий что ввод значения корректен

			bool incorrectInput = false;

			// Сообщение о некорректном значении ввода

			string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

			Console.WriteLine("Привет! Эта программа для отрисовки пирамидки");
			Console.WriteLine("Число N - это высота пирамидки");
			Console.WriteLine("ВНИМАНИЕ! Нельзя вводить некорректные значения N: 0, отрицательные или нецелые числа, строки");

			do
			{
				Console.Write("Ввведи число N: ");
				inputN = Console.ReadLine();

				if (int.TryParse(inputN, out parsedN) == false)
				{
					Console.WriteLine(wrongInputMassage);
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
						for (int n = 1; n <= parsedN; n++)
						{
							Console.Write(new string(' ', parsedN - n) + new string('*', n * 2 - 1));
							if (n < parsedN)
							{
								Console.WriteLine();
							}
						}
					}
				}
			} while (incorrectInput);
        }
	}
}
