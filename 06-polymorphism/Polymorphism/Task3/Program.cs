using System;

namespace Task3
{
    class Program
    {
        public static void PrintSeries(ISeries series, int lastElement)
        {
            series.Reset();

            for (int i = 0; i < lastElement; i++)
            {
                Console.WriteLine(series.GetCurrent());
                series.MoveNext();
            }

        }

        public static void PrintIndexable(IIndexable indexable, int lastElement)
        {

            for (int i = 0; i < lastElement; i++)
            {
                Console.WriteLine(indexable[i]);
            }

        }

        static void Main(string[] args)
        {
            ISeries series = new ArithmeticProgression(2, 5);
            PrintSeries(series, 100);

            Console.WriteLine();

            double[] seriesDouble = new double[10] { 1, 4, 5, 2, 3, 100, 12, 31, -123, 123 };
            IIndexable list = new List(seriesDouble);

            PrintIndexable(list, 10);
        }
    }
}
