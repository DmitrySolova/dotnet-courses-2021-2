using Entities;
using Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.List
{
    public class UsersListDAO : IUserDAO
    {
        private List<User> _usersList = new List<User>();

        private int _id = 0;
        public int GenerateID()
        {
            return ++_id;
        }

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

        
        public void Edit(User mainUser, User tempUser)
        {
            int index = _usersList.FindIndex((userToFind) => userToFind.Equals(mainUser));

            if (index == -1)
                throw new Exception("Cant find element");

            _usersList[index].FirstName = tempUser.FirstName;
            _usersList[index].LastName = tempUser.LastName;
            _usersList[index].Birthdate = tempUser.Birthdate;
            _usersList[index].Rewards = tempUser.Rewards;

        }

        
    }
}
