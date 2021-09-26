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

        //метод для обмена элементов
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        static void SortAndGetMinAndMaxValues(int[] array, out int min, out int max)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
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

            Console.WriteLine("min = " + min);
            Console.WriteLine("max = " + max);

        }
    }
}
