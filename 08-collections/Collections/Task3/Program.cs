using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static Dictionary<string, int> CountWords(string inputString)
        {
            Dictionary<string, int> commonWords = new Dictionary<string, int>();

            char[] delimiterChars = { ' ', ',', '.', ':', ';' };

            string[] delimitedString = inputString.ToLower().Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            var result = delimitedString.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => new { Word = x.Key, Frequency = x.Count() });

            foreach (var item in result)
            {
                commonWords.Add(item.Word, item.Frequency);
            }

            return commonWords;
        }
        static void Main(string[] args)
        {
            String inputString = "Lorem ipsum dolor sit amet, consectetur Lorem Lorem Lorem adipiscing elit. Nam ultrices ultrices venenatis amet ultrices nulla vitae porta. Curabitur.";
            Dictionary<string, int> commonWords = CountWords(inputString);

            foreach (var item in commonWords)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}
