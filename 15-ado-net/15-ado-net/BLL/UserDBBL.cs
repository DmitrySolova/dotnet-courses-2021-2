using DAL.List;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserDBBL : IUserBL
    {
        private IUserDAO _usersDAO;
        private int _id = 0;

        public UserDBBL(IUserDAO usersDAO)
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
            (from s in GetUsers()
             orderby s.FirstName ascending
             select s).ToList();
        }

        public void SortUserByFirstNameDesc()
        {
            (from s in GetUsers()
             orderby s.FirstName descending
             select s).ToList();
        }

        public void SortUserByLastNameAsc()
        {
            (from s in GetUsers()
             orderby s.LastName ascending
             select s).ToList();
        }

        public void SortUserByLastNameDesc()
        {
            (from s in GetUsers()
             orderby s.LastName descending
             select s).ToList();
        }

        public void SortUserByIDAsc()
        {
            (from s in GetUsers()
             orderby s.ID ascending
             select s).ToList();
        }

        public void SortUserByIDDesc()
        {
            (from s in GetUsers()
             orderby s.ID descending
             select s).ToList();
        }

        public void SortUserByBirthdateAsc()
        {
            (from s in GetUsers()
             orderby s.Birthdate ascending
             select s).ToList();
        }

        public void SortUserByBirthdateDesc()
        {
            (from s in GetUsers()
             orderby s.Birthdate descending
             select s).ToList().ToList();
        }

        public void SortUserByAgeeAsc()
        {
            (from s in GetUsers()
             orderby s.Age ascending
             select s).ToList();
        }

        public void SortUserByAgeDesc()
        {
            (from s in GetUsers()
             orderby s.Age descending
             select s).ToList();
        }
    }
}
