using System;
using System.Text.RegularExpressions;

namespace Task1
{
    public class User
    {
        DateTime _dateOfBirdth;
        string _name;
        string _lastName;
        string _patronymic;

        public User(DateTime dateOfBirdth, string name, string lastName, string patronymic)
        {
            if (DateTime.Now.Year - dateOfBirdth.Year < 0) throw new ArgumentOutOfRangeException($"{nameof(dateOfBirdth)} Год рождения не может быть отрицательным");
            if (Regex.IsMatch(name, @"(\d+|_+|\s+)")) throw new ArgumentException($"{nameof(name)} В имени есть недопустимые символы");
            if (Regex.IsMatch(lastName, @"(\d+|_+|\s+)")) throw new ArgumentException($"{nameof(lastName)} В фамилии есть недопустимые символы");
            if (Regex.IsMatch(patronymic, @"(\d+|_+|\s+)")) throw new ArgumentException($"{nameof(patronymic)} В отчестве есть недопустимые символы");
            _dateOfBirdth = dateOfBirdth;
            _name = name;
            _lastName = lastName;
            _patronymic = patronymic;
        }

        public int Age
        {
            get => DateTime.Now.Year - _dateOfBirdth.Year;
        }

        public string Name
        {
            get => _name;
        }

        public string LastName
        {
            get => _lastName;
        }

        public string Patronymic
        {
            get => _patronymic;
        }
    }

    class Employee : User
    {
        DateTime _startDate;
        string _title;

        public Employee(DateTime dateOfBirdth, string name, string lastName, string patronymic, DateTime startDate, string title)
            : base(dateOfBirdth, name, lastName, patronymic)
        {
            if (DateTime.Now.Year - startDate.Year < 0) throw new ArgumentOutOfRangeException($"{nameof(startDate)} Год стажа работы не может быть отрицательным");
            if (Regex.IsMatch(title, @"(\d+|_+|\s+)")) throw new ArgumentException($"{nameof(title)} В должности есть недопустимые символы");
            _startDate = startDate;
            _title = title;
        }

        public int Experience
        {
            get => DateTime.Now.Year - _startDate.Year;
        }

        public string Title
        {
            get => _title;
        }
    }

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
