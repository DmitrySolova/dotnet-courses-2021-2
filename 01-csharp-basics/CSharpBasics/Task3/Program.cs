using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{

			bool incorrectInput = false;

			string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

			Console.WriteLine("Привет! Эта программа для отрисовки пирамидки");
			Console.WriteLine("Число N - это высота пирамидки");
			Console.WriteLine("ВНИМАНИЕ! Нельзя вводить некорректные значения N: 0, отрицательные или нецелые числа, строки");

			int parsedN;

			do
			{
				Console.Write("Ввведи число N: ");
				string inputN = Console.ReadLine();

				if (!int.TryParse(inputN, out parsedN))
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
					}
				}
			} while (incorrectInput);

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
}
