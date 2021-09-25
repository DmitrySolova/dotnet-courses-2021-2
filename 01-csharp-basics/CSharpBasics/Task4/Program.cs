using System;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			// Строка, которую будем парсить на проверку правильности ввода N

			string inputN;

			// Количество секций пирамидки

			int parsedN;

			// Переменная-флаг, показывающий что ввод значения корректен

			bool incorrectInput = false;

			// Сообщение о некорректном значении ввода

			string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

			Console.WriteLine("Привет! Эта программа для отрисовки елочки");
			Console.WriteLine("Число N - это число секций елочки");
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
						for (int i = 1; i <= parsedN; i++)
						{
							for (int n = 1; n <= i; n++)
							{
								Console.Write(new string(' ', parsedN - n) + new string('*', n * 2 - 1));
								if (n < parsedN)
								{
									Console.WriteLine();
								}
							}
						}
					}
				}
			} while (incorrectInput);
		}
	}
}
