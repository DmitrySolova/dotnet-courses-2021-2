using System;
using System.Text.RegularExpressions;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите HTML текст: ");
            string stringWithHTML = Console.ReadLine();
            string modifiedString = Regex.Replace(stringWithHTML, "<[^>]+>", "_");
            Console.WriteLine("Результат замены: " + modifiedString);
        }
    }
}
