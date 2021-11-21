using Entities;
using Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.List
{
    public class UsersListDAO : IUserDAO
    {
        private List<User> _usersList = new List<User>();
        public void Add(User user)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            _usersList.Add(user);
        }

        public void ClearAndCopyRange(IEnumerable<User> users)
        {
            Clear();

            foreach (var user in users)
            {
                _usersList.Add(user);
            }
        }

        public void Clear()
        {
            _usersList.Clear();
        }

        public void Remove(User user)
        {
            if (user == null)
                throw new NullReferenceException("User is null");

            _usersList.Remove(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _usersList;
        }

        public void EditFirstName(User user, string newFirstName)
        {
            int index = _usersList.FindIndex((userToFind) => userToFind.Equals(user));

            if (index == -1)
                throw new Exception("Cant find element");
            _usersList[index].FirstName = newFirstName;
        }

        public void EditLastName(User user, string newLastName)
        {
            int index = _usersList.FindIndex((userToFind) => userToFind.Equals(user));

            if (index == -1)
                throw new Exception("Cant find element");

            _usersList[index].LastName = newLastName;
        }

        public void EditBirthdate(User user, DateTime newBirthdate)
        {
            int index = _usersList.FindIndex((userToFind) => userToFind.Equals(user));

            if (index == -1)
                throw new Exception("Cant find element");

            _usersList[index].Birthdate = newBirthdate;
        }

        public void EditRewards(User user, string[] rewards)
        {
            int index = _usersList.FindIndex((userToFind) => userToFind.Equals(user));

            if (index == -1)
                throw new Exception("Cant find element");

            _usersList[index].Rewards = rewards;
        }
    }
}
