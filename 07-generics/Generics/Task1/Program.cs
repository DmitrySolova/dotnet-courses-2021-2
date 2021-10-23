using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(6);
            dynamicArray.Add(78);
            dynamicArray.Add(32);
            dynamicArray.Add(-123);


            dynamicArray.ShowDynamicArray();
            Console.WriteLine();

            dynamicArray.Insert(0, 666);

            dynamicArray.ShowDynamicArray();
            Console.WriteLine();

            dynamicArray.Insert(4, 333);

            dynamicArray.ShowDynamicArray();
            Console.WriteLine();

            dynamicArray.Insert(dynamicArray.Length - 1, 999);

            dynamicArray.ShowDynamicArray();
            Console.WriteLine();

            dynamicArray.Remove(333);

            dynamicArray.ShowDynamicArray();
            Console.WriteLine();

            dynamicArray.Remove(666);

            dynamicArray.ShowDynamicArray();
            Console.WriteLine();
        }
    }
}
