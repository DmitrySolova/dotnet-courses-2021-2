using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserBL : IUserBL
    {
        private readonly IUserDAO _usersDAO;

        public UserBL(IUserDAO usersDAO)
        {
            _usersDAO = usersDAO;
        }

        public int CalculateAge(DateTime birthDate)
        {
            var now = DateTime.Now;

            var age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || now.Month == birthDate.Month && now.Day < birthDate.Day)
                age--;

            return age;
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


        public void Add(string firstName, string lastName, DateTime birthdate, string[] rewards)
        {
            ValidateFirstOrLastName(firstName);
            ValidateFirstOrLastName(lastName);
            ValidateBirthdate(birthdate);

            var user = new User
            {
                ID = _usersDAO.GenerateID(),
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Rewards = rewards
            };

            Add(user);
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

    }
}