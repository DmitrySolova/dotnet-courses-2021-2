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
            int N = 100;

            Stopwatch stopWatchStringBuilder = new Stopwatch();
            Stopwatch stopWatchString = new Stopwatch();

            stopWatchString.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            stopWatchString.Stop();

            stopWatchStringBuilder.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            stopWatchStringBuilder.Stop();

            TimeSpan tsString = stopWatchString.Elapsed;
            TimeSpan tsStringBuilder = stopWatchStringBuilder.Elapsed;

            Console.WriteLine("String: " + tsString.Milliseconds);
            Console.WriteLine("StringBuilder: " + tsStringBuilder.Milliseconds);

        }
    }
}
