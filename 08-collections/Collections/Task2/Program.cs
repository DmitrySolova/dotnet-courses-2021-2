using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6 };

            DynamicArray<int> dynamicArray = new DynamicArray<int>(intList);

            foreach (var element in dynamicArray)
            {
                Console.WriteLine(element);
            }

        }
    }
}
