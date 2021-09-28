using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void CountingTimeInString (string inputString)
        {
            string pattern = @"\b(0[0-9]|[10-23]|[1-9]):[0-5][0-9]\b";

            int matchCounter = 0;

            foreach (Match m in Regex.Matches(inputString, pattern))
                matchCounter++;

            Console.WriteLine("Время в тексте присутствует " + matchCounter + " раз.");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите текст: ");
            string inputString = Console.ReadLine();
            CountingTimeInString(inputString);
        }
    }
}
