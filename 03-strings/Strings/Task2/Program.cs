using System;

namespace Task2
{
    class Program
    {
        static string DoublingCharactersOfString(string firstString, string secondString)
        {
            string finalString = "";

            foreach (char ch in firstString)
                if (secondString.Contains(ch))
                {
                    finalString += ch;
                    finalString += ch;
                }
                else
                {
                    finalString += ch;
                }

            return finalString;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string firstString = Console.ReadLine();

            Console.Write("Введите вторую строку: ");
            string secondString = Console.ReadLine();

            string finalString = DoublingCharactersOfString(firstString, secondString);

            Console.WriteLine(finalString);
        }
    }
}
