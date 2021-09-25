using System;

namespace Task5
{
	class Program
	{
		static void Main(string[] args)
		{
			int sum = 0;
			int n = 1000;
			for(int i = 0; i < n; i++)
            {
				if (i % 3 == 0 | i % 5 == 0)
                {
					sum += i;
                }
            }
			Console.WriteLine(sum);
		}
	}
}
