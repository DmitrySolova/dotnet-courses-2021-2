using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        private static Node<T> CreateCircularList<T>(ICollection<T> collection)
        {
            Node<T> firstNode = null;
            Node<T> previousNode = null;
            foreach (var item in collection)
            {
                var newNode = new Node<T>(item);
                if (firstNode == null)
                {
                    firstNode = newNode;
                }
                else
                {
                    previousNode.Next = newNode;
                }
                previousNode = newNode;
            }
            previousNode.Next = firstNode;
            return firstNode;
        }

        public static void RemoveEachSecondItem<T>(ICollection<T> collection)
        {
            var elementsCount = collection.Count();
            if (elementsCount == 0)
                throw new Exception("Empty collection");

            var firstNode = CreateCircularList(collection);
            var isOdd = false;
            var currentNode = firstNode;
            Node<T> previousNode = null;
            while (elementsCount > 1)
            {
                if (isOdd)
                {
                    previousNode.Next = currentNode.Next;
                    elementsCount--;
                }
                else
                {
                    previousNode = currentNode;
                }
                currentNode = currentNode.Next;
                isOdd = !isOdd;
            }
            collection.Clear();
            collection.Add(currentNode.Data);
        }

        static void Main(string[] args)
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6 };
            RemoveEachSecondItem(intList);
            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            LinkedList<int> intLinkedList = new LinkedList<int>();
            intLinkedList.AddLast(1);
            intLinkedList.AddLast(3);
            intLinkedList.AddLast(65);
            intLinkedList.AddLast(15);
            intLinkedList.AddLast(65);
            intLinkedList.AddLast(-125);
            intLinkedList.AddLast(1225);
            intLinkedList.AddLast(-1231);
            RemoveEachSecondItem(intLinkedList);
            foreach (var item in intLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
