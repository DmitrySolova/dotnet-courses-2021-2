using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
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
}
