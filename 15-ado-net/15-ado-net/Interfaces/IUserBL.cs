using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserBL
    {
        public int CalculateAge(DateTime birthDate);

        public void ValidateFirstOrLastName(string firstOrLastName);

        public void ValidateBirthdate(DateTime birthdate);

        public void Add(string firstName, string lastName, DateTime birthdate, string[] rewards);

        public void Add(User user);

        public void Remove(User user);

        public void Edit(User mainUser, User tempUser);

        public IEnumerable<User> GetUsers();

    }
}
