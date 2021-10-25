using System;
using System.Threading;

namespace Task3
{
    class Program
    {
        delegate void ThreadHandler(string massage);
        private static event ThreadHandler ThreadNotify;

        public static void ArrayToInlineString(string[] stringsArray)
        {
            string totalString = "";
            foreach (string element in stringsArray)
            {
                totalString += $"{element} ";
            }
            Console.WriteLine(totalString);
        }
        public static int CompareStrings(string s1, string s2)
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

            ThreadNotify?.Invoke($"Сортировка началась");
            ArrayToInlineString(stringsArray);

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
            ThreadNotify?.Invoke($"Сортировка завершилась");
            ArrayToInlineString(stringsArray);
        }

        public static Thread SortAsync(string[] stringsArray, Func<string, string, int> logicFunc)
        {
            return new Thread(() => Sort(stringsArray, CompareStrings));
        }
        public static void ThreadMassage(string massage)
        {
            Console.WriteLine(massage);
        }
        static void Main(string[] args)
        {
            var strings1 = new string[5] { "absasf", "adss", "abs", "bs", "abs" };
            var strings2 = new string[5] { "absфыаasf", "adмывss", "a3213bs", "b32s", "aпвыbs" };
            var strings3 = new string[5] { "absмавмasf", "aвфывфdss", "aфыаbs", "паbs", "ab64364s" };

            ThreadNotify += ThreadMassage;

            strings1.ToString();

            var th1 = SortAsync(strings1, CompareStrings);
            var th2 = SortAsync(strings2, CompareStrings);
            var th3 = SortAsync(strings3, CompareStrings);

            th1.Start();
            th2.Start();
            th3.Start();

        }
    }
}
