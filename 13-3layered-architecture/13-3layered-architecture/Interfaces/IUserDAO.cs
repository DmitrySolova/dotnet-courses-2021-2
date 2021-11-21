using Entities;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IUserDAO
    {
        public void Add(User user);

        public void ClearAndCopyRange(IEnumerable<User> users);
        public void Remove(User user);

        public void Clear();

        public void EditRewards(User user, string[] rewards);
        public void EditFirstName(User user, string newFirstName);

        public void EditLastName(User user, string newLastName);

        public void EditBirthdate(User user, DateTime newBirthdate);

        public
        IEnumerable<User> GetUsers();
    }
}
