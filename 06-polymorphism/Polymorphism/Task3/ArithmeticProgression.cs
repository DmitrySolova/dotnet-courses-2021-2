using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class ArithmeticProgression : IIndexableSeries
    {
        double start, step;
        int index;

        public ArithmeticProgression(double start, double step)
        {
            this.start = start;
            this.step = step;
            this.index = 0;
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
            index = 0;
        }

        public double this[int index]
        {
            get => start + step * index;
        }
    }
}
