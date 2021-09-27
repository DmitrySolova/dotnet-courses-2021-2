using System;
using System.Globalization;

namespace Task3
{
    class Program
    {
        static void CultureDifference(CultureInfo cultureA, CultureInfo cultureB)
        {
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Культура", cultureA.DisplayName, cultureB.DisplayName);
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Дата и время", DateTime.Now.ToString(cultureA), DateTime.Now.ToString(cultureB));
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Дата (развернуто)", DateTime.Now.ToString("D", cultureA), DateTime.Now.ToString("D", cultureB));
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Дата (коротко)", DateTime.Now.ToString("d", cultureA), DateTime.Now.ToString("d", cultureB));
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Время (развернуто)", DateTime.Now.ToString("T", cultureA), DateTime.Now.ToString("T", cultureB));
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Время (коротко)", DateTime.Now.ToString("t", cultureA), DateTime.Now.ToString("t", cultureB));
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Разделитель дробной и целой части", 12.345.ToString(cultureA), 12.345.ToString(cultureB));
            Console.WriteLine("{0,-40}{1,-47}{2,-25}", "Разделитель групп разрядов", String.Format(cultureA, "{0:0,0}", 1234567890), String.Format(cultureB, "{0:0,0}", 1234567890));
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            CultureInfo RuCulture = new CultureInfo("ru-RU");
            CultureInfo EnCulture = new CultureInfo("en-GB");
            CultureInfo InvCulture = CultureInfo.InvariantCulture;

            CultureDifference(RuCulture, EnCulture);
            CultureDifference(EnCulture, InvCulture);
            CultureDifference(RuCulture, InvCulture);
        }
    }
}
