using DAL.List;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class RewardBL
    {
        private IRewardDAO rewardsDAO;
        private int _id = 0;

        public RewardBL()
        {
            rewardsDAO = new RewardsListDAO();
        }

        private int GenerateID()
        {
            return ++_id;
        }

        private static void ValidateTitle(string title)
        {
            if (title == "" || title == null)
                throw new ArgumentException("Title is empty or null");

            if (title.Length > 50)
                throw new ArgumentOutOfRangeException("Title cant be > 50 characters");

        }

        private static void ValidateDescription(string description)
        {
            if (description == "" || description == null)
                throw new ArgumentException("Description is empty or null");

            if (description.Length > 250)
                throw new ArgumentOutOfRangeException("Description cant be > 250 characters");

        }

        public IEnumerable<Reward> InitList()
        {
            Add("Золотой глобус", "Премия для исскуства");
            Add("Нобелевская премия", "Премия для науки");
            Add("Золотой диск", "Премия для музыки");

            return GetRewards();
        }

        public void Add(string title, string description)
        {
            ValidateTitle(title);
            ValidateDescription(description);

            Reward reward = new Reward
            {
                ID = GenerateID(),
                Title = title,
                Description = description
            };

            this.Add(reward);
        }

        public void Add(Reward reward)
        {
            if (reward == null)
                throw new NullReferenceException("Reward is null");

            rewardsDAO.Add(reward);
        }

        public void Remove(Reward reward)
        {
            if (reward == null)
                throw new NullReferenceException("Reward is null");

            rewardsDAO.Remove(reward);
        }

        public void EditTitle(Reward reward, string newTitle)
        {
            if (reward == null)
                throw new NullReferenceException("Reward is null");

            ValidateTitle(newTitle);

            rewardsDAO.EditTitle(reward, newTitle);
        }

        public void EditDescription(Reward reward, string newDescription)
        {
            if (reward == null)
                throw new NullReferenceException("Reward is null");

            ValidateDescription(newDescription);

            rewardsDAO.EditDescription(reward, newDescription);
        }

        public IEnumerable<Reward> GetRewards()
        {
            return rewardsDAO.GetRewards();
        }

        public void SortRewardByTitleAsc()
        {
            rewardsDAO.ClearAndCopyRange((from s in GetRewards()
                                          orderby s.Title ascending
                                          select s).ToList());
        }

        public void SortRewardByTitleDesc()
        {
            rewardsDAO.ClearAndCopyRange((from s in GetRewards()
                                          orderby s.Title descending
                                          select s).ToList());
        }

        public void SortRewardByIDAsc()
        {
            rewardsDAO.ClearAndCopyRange((from s in GetRewards()
                                          orderby s.Description ascending
                                          select s).ToList());
        }

        public void SortRewardByIDDesc()
        {
            rewardsDAO.ClearAndCopyRange((from s in GetRewards()
                                          orderby s.Description descending
                                          select s).ToList());
        }
    }
}
