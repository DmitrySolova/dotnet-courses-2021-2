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

        public User (DateTime dateOfBirdth, string name, string lastName, string patronymic)
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
    class Program
    {
        static void Main(string[] args)
        {
            var dateOfBirdth = new DateTime(2008, 10, 6);
            User user = new User(dateOfBirdth, "Дмитрий", "Пешков", "Александрович");
            Console.WriteLine(user.Age);
            Console.WriteLine(user.LastName);
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Patronymic);

        }
    }

}
