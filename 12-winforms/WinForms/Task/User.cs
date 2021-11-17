using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public class User
    {
        private int _id = 0;
        private string _firstName = "";
        private string _lastName = "";
        private DateTime _birthdate;
        private int _age = 0;


        public User()
        {

        }
        public User(int id)
        {
            ID = id;
        }
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
            set => _id = value;
        }

        public string FirstName
        {
            get => _firstName;
            set =>  _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public DateTime Birthdate
        {
            get => _birthdate.Date;
            set => _birthdate = value;
        }

        public int Age
        {
            get
            {
                _age = CalculateAge(Birthdate);
                return _age;
            }
        }

        public static int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

    }
}
