using System;

namespace Task2
{
    class Program
    {
        static int[,,] GenerateThreeDimensionalArray()
        {
            int[,,] array = new int[3, 3, 3];

            var rand = new Random();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        array[x, y, z] = rand.Next(-101, 101);
                    }
                }
            }

            return array;
        }

        static void PrintThreeDimensionalArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.WriteLine(array[i, j, k]);
                    }
                }
            }
        }
        static void ReplacePositiveElementsWithZero(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[,,] array = GenerateThreeDimensionalArray();
            PrintThreeDimensionalArray(array);
            ReplacePositiveElementsWithZero(array);
            PrintThreeDimensionalArray(array);
        }
    }
}
