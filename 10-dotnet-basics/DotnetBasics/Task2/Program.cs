using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dateOfBirdth = new DateTime(2005, 5, 1);
            var startDate = new DateTime(2019, 3, 5);
            Employee employee1 = new Employee(dateOfBirdth, "Сергей", "Деникин", "Викторович", startDate, "Специалист");
            Employee employee2 = new Employee(dateOfBirdth, "Анатолий", "Кумарин", "Петрович", startDate, "Специалист");
            Employee employee3 = new Employee(dateOfBirdth, "Андрей", "Раздоров", "Николаевич", startDate, "Директор");
            Console.WriteLine(employee1.Equals(employee3));
        }
    }
}
