using System;

namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{

			bool incorrectInput = false;

			string wrongInputMassage = "Ошибка! Ввести можно только целые числа > 0";

			Console.WriteLine("Привет! Эта программа для отрисовки елочки");
			Console.WriteLine("Число N - это число секций елочки");
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
}
