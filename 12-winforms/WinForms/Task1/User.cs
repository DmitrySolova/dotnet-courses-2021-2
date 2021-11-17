using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class User
    {
        private int _id = 0;
        private string _firstName = "";
        private string _lastName = "";
        private DateTime _birthdate;
        private int _age = 0;

        public User(int id, string firstName, string lastName, DateTime birthdate)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public int ID
        {
            get => _id;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("Имя не может быть > 50 символов");
                }

                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("Фамилия не может быть > 50 символов");
                }

                _lastName = value;
            }
        }

        public DateTime Birthdate
        {
            get => _birthdate;
            set
            {
                if (CalculateAge(value) > 150)
                {
                    throw new Exception("Возраст не может быть > 150 лет");
                }

                _birthdate = value;
            }
        }

        public int Age
        {
            get
            {
                _age = CalculateAge(Birthdate);
                return _age;
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

    }
}
