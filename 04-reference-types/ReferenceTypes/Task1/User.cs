using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task1
{
    class User
    {
        private DateTime _dateOfBirdth;
        private string _name;
        private string _lastName;
        private string _patronymic;
        private string _regexPattern = @"(\d+|_+|\s+)";

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
}
