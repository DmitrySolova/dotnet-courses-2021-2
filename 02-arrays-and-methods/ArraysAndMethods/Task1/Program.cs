using System;

namespace Task1
{
    class Program
    {
        static int[] GenerateArray()
        {
            var rand = new Random();
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(-101, 101);
            }

            return arr;
        }

        static void SortAndGetMinAndMaxValues(int[] array, out int min, out int max)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
                }
            }

            min = array[0];

            max = array[array.Length - 1];
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        static void Main(string[] args)
        {
            int min;
            int max;

            int[] arr = Task1.Program.GenerateArray();
            Task1.Program.SortAndGetMinAndMaxValues(arr, out min, out max);
            Task1.Program.PrintArray(arr);

        }
    }
}
