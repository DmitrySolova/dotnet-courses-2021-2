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
            object employee3 = new Employee(dateOfBirdth, "Андрей", "Раздоров", "Николаевич", startDate, "Директор");
            var bol = employee1.Equals(employee3); // вернет False
            Console.WriteLine(bol);
        }
    }
}
