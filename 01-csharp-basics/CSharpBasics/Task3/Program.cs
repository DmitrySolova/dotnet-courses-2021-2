using System;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Высота елочки");
            int width = int.Parse(Console.ReadLine());
			for (int i = 1; i < width + 1; i++)
			{
				for (int n = i; n < width; n++)
				{
					Console.Write(" ");
				}
				for (int k = 0; k != i * 2 - 1; k++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}
        }
	}
}
