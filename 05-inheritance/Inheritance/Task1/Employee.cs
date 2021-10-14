using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task1
{
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
}
