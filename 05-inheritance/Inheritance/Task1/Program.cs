using System;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateOfBirdth = new DateTime(2005, 5, 1);
            var startDate = new DateTime(2019, 3, 5);
            Employee employee = new Employee(dateOfBirdth, "Анатолий", "Кумарин", "Петрович", startDate, "Специалист");
            Console.WriteLine(employee.Age);
            Console.WriteLine(employee.LastName);
            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Patronymic);
            Console.WriteLine(employee.Experience);
            Console.WriteLine(employee.Title);
        }
    }
}
