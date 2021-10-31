using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        private static int CompareStrings(string s1, string s2)
        {
            if (s1.Length == s2.Length)
            {
                int boolIntAlphabeticalOrder = String.Compare(s1, s2);
                if (boolIntAlphabeticalOrder == 0)
                {
                    return 0;
                }
                if (boolIntAlphabeticalOrder < 0)
                {
                    return -1;
                }
            }
            if (s1.Length < s2.Length)
            {
                return -1;
            }
            return 1;
        }
        // сортировку по алфавиту перенести в логическую функцию
        public static void Sort(string[] stringsArray, Func<string, string, int> logicFunc)
        {
            string tempString = "";

            for (int i = 0; i < stringsArray.Length; i++)
            {
                for (int j = i + 1; j < stringsArray.Length; j++)
                {
                    if (logicFunc(stringsArray[i], stringsArray[j]) >= 0)
                    {
                        tempString = stringsArray[i];
                        stringsArray[i] = stringsArray[j];
                        stringsArray[j] = tempString;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var strings = new string[5] { "absasf", "adss", "abs", "bs", "abs" };

            Sort(strings, CompareStrings);

        }
    }
}
