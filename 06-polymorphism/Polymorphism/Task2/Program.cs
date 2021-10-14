using System;

namespace Task2
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
        static void Main(string[] args)
        {
            ISeries ser1 = new GeometricProgression(2, 4);
            PrintSeries(ser1, 10);
        }
    }
}
