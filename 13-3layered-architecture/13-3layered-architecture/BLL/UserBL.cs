using DAL.List;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserBL
    {
        private IUserDAO usersDAO;
        private int _id = 0;

        public UserBL()
        {
            usersDAO = new UsersListDAO();
        }

        private static int CalculateAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
                age--;

            return age;
        }

        private int GenerateID()
        {
            return ++_id;
        }

        private static void ValidateFirstOrLastName(string firstOrLastName)
        {
            if (firstOrLastName == "" || firstOrLastName == null)
                throw new ArgumentException("First name is empty or null");

            if (firstOrLastName.Length > 50)
                throw new ArgumentOutOfRangeException("First name cant be > 50 characters");

        }

        private static void ValidateBirthdate(DateTime birthdate)
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
            Add("Иван", "Фисташин", new DateTime(2003, 08, 04), new string[0]);
            Add("Олег", "Петров", new DateTime(1995, 01, 12), new string[0]);
            Add("Мария", "Гоголева", new DateTime(1980, 12, 29), new string[0]);

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

            usersDAO.Add(user);
        }

        public void Remove(User user)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            usersDAO.Remove(user);
        }

        public void EditFirstName(User user, string newFirstName)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            ValidateFirstOrLastName(newFirstName);

            usersDAO.EditFirstName(user, newFirstName);
        }

        public void EditLastName(User user, string newLastName)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            ValidateFirstOrLastName(newLastName);

            usersDAO.EditLastName(user, newLastName);
        }

        public void EditBirthdate(User user, DateTime newBirthdate)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            ValidateBirthdate(newBirthdate);

            usersDAO.EditBirthdate(user, newBirthdate);
        }

        public void EditRewards(User user, string[] rewards)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            usersDAO.EditRewards(user, rewards);
        }

        public IEnumerable<User> GetUsers()
        {
            return usersDAO.GetUsers();
        }

        public void SortUserByFirstNameAsc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.FirstName ascending
                               select s).ToList());
        }

        public void SortUserByFirstNameDesc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.FirstName descending
                               select s).ToList());
        }

        public void SortUserByLastNameAsc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.LastName ascending
                               select s).ToList());
        }

        public void SortUserByLastNameDesc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.LastName descending
                               select s).ToList());
        }

        public void SortUserByIDAsc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.ID ascending
                               select s).ToList());
        }

        public void SortUserByIDDesc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.ID descending
                               select s).ToList());
        }

        public void SortUserByBirthdateAsc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Birthdate ascending
                               select s).ToList());
        }

        public void SortUserByBirthdateDesc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Birthdate descending
                               select s).ToList().ToList());
        }

        public void SortUserByAgeeAsc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Age ascending
                               select s).ToList());
        }

        public void SortUserByAgeDesc()
        {
            usersDAO.ClearAndCopyRange((from s in GetUsers()
                               orderby s.Age descending
                               select s).ToList());
        }
    }
}
