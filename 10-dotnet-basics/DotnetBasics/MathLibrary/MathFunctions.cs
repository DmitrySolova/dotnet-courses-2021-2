using System;

namespace MathLibrary
{
    public class MathFunctions
    {
        public static long Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        public static double Power(double x, double y)
        {
            if (y == 0)
            {
                return 1;
            }

            if (y % 2 == 0)
            {
                var p = Power(x, y / 2);
                return p * p;
            }
            else
            {
                return x * Power(x, y - 1);
            }
        }
    }
}
