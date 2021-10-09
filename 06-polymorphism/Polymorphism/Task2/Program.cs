using System;

namespace Task2
{
    interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
        void Reset();

    }

    class GeometricProgression : ISeries
    {

        double start, step;
        int index;

        public GeometricProgression(double start, double step)
        {
            this.start = start;
            this.step = step;
            this.index = 1;
        }

        public double GetCurrent()
        {
            return start * Math.Pow(step, index - 1);
        }
        public bool MoveNext()
        {
            index++;
            return true;
        }
        public void Reset()
        {
            index = 1;
        }

    }
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
