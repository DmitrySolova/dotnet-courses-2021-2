using Entities;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUserDAO
    {
        public int GenerateID();
        public void Add(User user);
        public void ClearAndCopyRange(IEnumerable<User> users);
        public void Remove(User user);

        public void Clear();

        public void Edit(User mainUser, User tempUser);

        public IEnumerable<User> GetUsers();
    }
}
