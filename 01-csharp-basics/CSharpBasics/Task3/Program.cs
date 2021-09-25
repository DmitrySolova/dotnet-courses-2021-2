﻿using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			// Строка, которую будем парсить на проверку правильности ввода N

			string inputN;

			// Высота елочки

			int parsedN;

			// Переменная-флаг, показывающий что ввод значения корректен

			bool incorrectInput = false;

			// Сообщение о некорректном значении ввода

			string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

			Console.WriteLine("Привет! Эта программа для отрисовки елочки");
			Console.WriteLine("Число N - это высота елочки");
			Console.WriteLine("Например: N = 3 даст следующую картинку");

			Console.WriteLine("");
			Console.WriteLine("  *");
			Console.WriteLine(" ***");
			Console.WriteLine("*****");
			Console.WriteLine("");

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
						for (int i = 1; i < parsedN + 1; i++)
						{
							for (int n = i; n < parsedN; n++)
							{
								Console.Write(" ");
							}
							for (int k = 0; k != i * 2 - 1; k++)
							{
								Console.Write("*");
							}
							if (i != parsedN)
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
