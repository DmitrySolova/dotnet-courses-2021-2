using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    abstract class Figure
    {
        protected int _x;
        protected int _y;

        public Figure(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get => _x;
        }

        public int Y
        {
            get => _y;
        }

        public abstract void Draw();
    }
}
