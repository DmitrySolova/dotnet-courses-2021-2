using System;
using System.Text.RegularExpressions;

namespace Task1
{
    public class User
    {
        protected DateTime _dateOfBirdth;
        protected string _name;
        protected string _lastName;
        protected string _patronymic;
        protected string _regexPattern = @"(\d+|_+|\s+)";

        public User(DateTime dateOfBirdth, string name, string lastName, string patronymic)
        {
            if (DateTime.Now.Year - dateOfBirdth.Year < 0) throw new ArgumentOutOfRangeException($"{nameof(dateOfBirdth)} Не корректный год рождения");
            if (Regex.IsMatch(name, _regexPattern)) throw new ArgumentException($"{nameof(name)} В имени есть недопустимые символы");
            if (Regex.IsMatch(lastName, _regexPattern)) throw new ArgumentException($"{nameof(lastName)} В фамилии есть недопустимые символы");
            if (Regex.IsMatch(patronymic, _regexPattern)) throw new ArgumentException($"{nameof(patronymic)} В отчестве есть недопустимые символы");
            _dateOfBirdth = dateOfBirdth;
            _name = name;
            _lastName = lastName;
            _patronymic = patronymic;
        }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - _dateOfBirdth.Year;
                if (DateTime.Now.DayOfYear < _dateOfBirdth.DayOfYear)
                {
                    age--;
                }
                return age;
            }
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
        private DateTime _startDate;
        private string _title;

        public Employee(DateTime dateOfBirdth, string name, string lastName, string patronymic, DateTime startDate, string title)
            : base(dateOfBirdth, name, lastName, patronymic)
        {
            if (DateTime.Now.Year - startDate.Year < 0) throw new ArgumentOutOfRangeException($"{nameof(startDate)} Некорректный год стажа работы");
            if (Regex.IsMatch(title, _regexPattern)) throw new ArgumentException($"{nameof(title)} В должности есть недопустимые символы");
            _startDate = startDate;
            _title = title;
        }

        public int Experience
        {
            get
            {
                int experience = DateTime.Now.Year - _startDate.Year;
                if (DateTime.Now.DayOfYear < _startDate.DayOfYear)
                {
                    experience--;
                }
                return experience;
            }
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
