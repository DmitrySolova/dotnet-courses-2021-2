using System;
using System.Text.RegularExpressions;

namespace Task6
{
    class Program
    {
        static void CheckNotation(string inputString)
        {
            int numberInt;
            float numberFloat;
            string pattern = @"-?\d+(.|,)?\d*(e|E)-?\d+";

            if (Regex.IsMatch(inputString, pattern))
            {
                Console.WriteLine("Это число в научной нотации");
            }
            else if (int.TryParse(inputString, out numberInt))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else if (float.TryParse(inputString.Replace('.', ','), out numberFloat))
            {
                Console.WriteLine("Это число в обычной нотации");
            }
            else
            {
                Console.WriteLine("Это не число");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string inputString = Console.ReadLine();
            CheckNotation(inputString);
        }
    }
}
