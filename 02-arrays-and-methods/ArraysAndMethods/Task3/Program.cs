using System;

namespace Task3
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

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static int GetSumOfNonNegativeElements(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    sum += array[i];
                }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int[] array = Task3.Program.GenerateArray();
            Task3.Program.PrintArray(array);
            int sum = Task3.Program.GetSumOfNonNegativeElements(array);
            Console.WriteLine(sum);
        }
    }
}
