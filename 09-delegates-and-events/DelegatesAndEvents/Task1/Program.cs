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
                return 0;
            }
            if (s1.Length < s2.Length)
            {
                return -1;
            }
            return 1;
        }

        public static void Sort(string[] stringsArray, Func<string, string, int> logicFunc)
        {
            string tempString = "";

            for (int i = 0; i < stringsArray.Length; i++)
            {
                for (int j = i + 1; j < stringsArray.Length; j++)
                {
                    if (logicFunc(stringsArray[i], stringsArray[j]) >= 0)
                    {

                        if (logicFunc(stringsArray[i], stringsArray[j]) == 0)
                        {
                            int boolIntAlphabeticalOrder = String.Compare(stringsArray[i], stringsArray[i + 1]);
                            if (boolIntAlphabeticalOrder <= 0)
                            {
                                continue;
                            }
                        }

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
