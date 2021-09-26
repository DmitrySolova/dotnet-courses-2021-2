using System;

namespace Task4
{
    class Program
    {
        static int[,] GenerateTwoDimensionalArray()
        {
            int[,] array = new int[2, 10];

            var rand = new Random();

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    array[x, y] = rand.Next(-101, 101);
                }
            }

            return array;
        }

        static void PrintTwoDimensionalArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.WriteLine(array[i, j]);
                }
                Console.WriteLine(" ");
            }
        }

        static int GetSumOfElementsOnEvenPositions(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += array[i, j];
                    }
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int[,] array = Task4.Program.GenerateTwoDimensionalArray();
            Task4.Program.PrintTwoDimensionalArray(array);
            int sum = Task4.Program.GetSumOfElementsOnEvenPositions(array);
            Console.WriteLine("");
            Console.WriteLine("sum is " + sum);
        }
    }
}
