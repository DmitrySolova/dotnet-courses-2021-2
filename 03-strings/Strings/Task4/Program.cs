using System;
using System.Diagnostics;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 10000;

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            stopWatch.Stop();

            Console.WriteLine("String: " + stopWatch.ElapsedMilliseconds);

            stopWatch.Reset();

            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            stopWatch.Stop();


            Console.WriteLine("StringBuilder: " + stopWatch.ElapsedMilliseconds);

        }
    }
}
