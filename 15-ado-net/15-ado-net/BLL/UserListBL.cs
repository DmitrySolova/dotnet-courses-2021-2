using DAL.List;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserListBL : IUserBL
    {
        private IUserDAO _usersDAO;
        private int _id = 0;

        public UserListBL(IUserDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }

        public int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

        public int GenerateID()
        {
            return ++_id;
        }

        public void ValidateFirstOrLastName(string firstOrLastName)
        {
            if (firstOrLastName == "" || firstOrLastName == null)
                throw new ArgumentException("First name is empty or null");

            if (firstOrLastName.Length > 50)
                throw new ArgumentOutOfRangeException("First name cant be > 50 characters");

        }

        public void ValidateBirthdate(DateTime birthdate)
        {
            if (birthdate == null)
                throw new NullReferenceException("Birthdate is null");

            if (DateTime.Compare(birthdate, DateTime.Now) > 0)
                throw new ArgumentOutOfRangeException("Birthdate cannot be less than the current date");

            if (CalculateAge(birthdate) > 150)
                throw new ArgumentOutOfRangeException("Age can't be > 150 years");

        }

        public IEnumerable<User> InitList()
        {
            _usersDAO.Clear();

            User user1 = new User
            {
                FirstName = "Иван",
                LastName = "Фисташин",
                Birthdate = new DateTime(2003, 08, 04),
                Rewards = new string[0]
            };

            User user2 = new User
            {
                FirstName = "Олег",
                LastName = "Петров",
                Birthdate = new DateTime(1995, 01, 12),
                Rewards = new string[0]
            };

            User user3 = new User
            {
                FirstName = "Мария",
                LastName = "Гоголева",
                Birthdate = new DateTime(1980, 12, 29),
                Rewards = new string[0]
            };

            _usersDAO.Add(user1);
            _usersDAO.Add(user2);
            _usersDAO.Add(user3);

            //Add("Иван", "Фисташин", new DateTime(2003, 08, 04), new string[0]);
            //Add("Олег", "Петров", new DateTime(1995, 01, 12), new string[0]);
            //Add("Мария", "Гоголева", new DateTime(1980, 12, 29), new string[0]);

            return GetUsers();
        }

        public void Add(string firstName, string lastName, DateTime birthdate, string[] rewards)
        {
            ValidateFirstOrLastName(firstName);
            ValidateFirstOrLastName(lastName);
            ValidateBirthdate(birthdate);

            User user = new User
            {
                ID = GenerateID(),
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Rewards = rewards
            };

            this.Add(user);
        }


        public void Add(User user)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            _usersDAO.Add(user);
        }

        public void Remove(User user)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            _usersDAO.Remove(user);
        }

        public void Edit(User mainUser, User tempUser)
        {
            if (mainUser == null)
                throw new NullReferenceException("Main User is null");

            if (tempUser == null)
                throw new NullReferenceException("Temp User is null");

            ValidateFirstOrLastName(tempUser.FirstName);
            ValidateFirstOrLastName(tempUser.LastName);
            ValidateBirthdate(tempUser.Birthdate);

            _usersDAO.Edit(mainUser, tempUser);
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersDAO.GetUsers();
        }

        public void SortUserByFirstNameAsc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.FirstName ascending
                               select s).ToList());
        }

        public void SortUserByFirstNameDesc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.FirstName descending
                               select s).ToList());
        }

        public void SortUserByLastNameAsc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.LastName ascending
                               select s).ToList());
        }

        public void SortUserByLastNameDesc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.LastName descending
                               select s).ToList());
        }

        public void SortUserByIDAsc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.ID ascending
                               select s).ToList());
        }

        public void SortUserByIDDesc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.ID descending
                               select s).ToList());
        }

        public void SortUserByBirthdateAsc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Birthdate ascending
                               select s).ToList());
        }

        public void SortUserByBirthdateDesc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Birthdate descending
                               select s).ToList().ToList());
        }

        public void SortUserByAgeeAsc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Age ascending
                               select s).ToList());
        }

        public void SortUserByAgeDesc()
        {
            _usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Age descending
                               select s).ToList());
        }
    }
}
