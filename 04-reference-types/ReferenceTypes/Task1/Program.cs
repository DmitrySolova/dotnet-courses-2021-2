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

        public User (DateTime dateOfBirdth, string name, string lastName, string patronymic)
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
    class Program
    {
        static void Main(string[] args)
        {
            var dateOfBirdth = new DateTime(2008, 5, 1, 8, 30, 52);
            User user = new User(dateOfBirdth, "Дмитрий", "Пешков", "Александрович");
            Console.WriteLine(user.Age);
            Console.WriteLine(user.LastName);
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Patronymic);

        }
    }

}
