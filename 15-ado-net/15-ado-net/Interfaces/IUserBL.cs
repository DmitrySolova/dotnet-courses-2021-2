using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUserBL
    {
        public int CalculateAge(DateTime birthDate);

        public int GenerateID();

        public void ValidateFirstOrLastName(string firstOrLastName);

        public void ValidateBirthdate(DateTime birthdate);

        public IEnumerable<User> InitList();

        public void Add(string firstName, string lastName, DateTime birthdate, string[] rewards);


        public void Add(User user);

        public void Remove(User user);

        public void Edit(User mainUser, User tempUser);

        public IEnumerable<User> GetUsers();

        public void SortUserByFirstNameAsc();

        public void SortUserByFirstNameDesc();

        public void SortUserByLastNameAsc();

        public void SortUserByLastNameDesc();

        public void SortUserByIDAsc();

        public void SortUserByIDDesc();

        public void SortUserByBirthdateAsc();

        public void SortUserByBirthdateDesc();

        public void SortUserByAgeeAsc();

        public void SortUserByAgeDesc();
    }
}
