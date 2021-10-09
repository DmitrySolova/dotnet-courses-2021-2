using System;

namespace Task3
{
    interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
        void Reset();

    }

    interface IIndexable
    {
        double this[int index] { get;  }
    }

    interface IIndexableSeries : ISeries, IIndexable
    {

    }

    class ArithmeticProgression : IIndexableSeries
    {
        double start, step;
        int index;

        public ArithmeticProgression(double start, double step)
        {
            this.start = start;
            this.step = step;
            this.index = 1;
        }

        public double GetCurrent()
        {
            return start + step * index;
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

        public double this[int index]
        {
            get => start + step * index;
        }
    }

    class List : IIndexableSeries
    {
        private double[] series;
        private int currentIndex;

        public List(double[] series)
        {
            this.series = series;
            currentIndex = 0;
        }

        public double GetCurrent()
        {
            return series[currentIndex];
        }
        public bool MoveNext()
        {
            currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
            return true;
        }
        public void Reset()
        {
            currentIndex = 0;
        }
        public double this[int index]
        {
            get => series[index];
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
