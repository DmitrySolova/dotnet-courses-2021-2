using System;

namespace Strings
{
    class Program
    {
        static double AverageLenghtWords(string inputString)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] words = inputString.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            double tempAverageLenght = 0;

            foreach (string word in words)
            {
                tempAverageLenght += word.Length;
            }

            double averageLength = tempAverageLenght / words.Length;

            return averageLength;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Эта программа для подсчета средней длины слова во введенной текстовой строке");
            Console.WriteLine("Введи строку: ");

            string inputString = Console.ReadLine();
            double averageLength = AverageLenghtWords(inputString);
            Console.WriteLine(averageLength);
        }
    }
}
