using DAL.List;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class RewardDBBL : IRewardBL
    {
        private IRewardDAO _rewardsDAO;
        private int _id = 0;

        public RewardDBBL(IRewardDAO rewardDAO)
        {
            _rewardsDAO = rewardDAO;
        }

        public int GenerateID()
        {
            return ++_id;
        }

        public void ValidateTitle(string title)
        {
            if (title == "" || title == null)
                throw new ArgumentException("Title is empty or null");

            if (title.Length > 50)
                throw new ArgumentOutOfRangeException("Title cant be > 50 characters");

        }

        public void ValidateDescription(string description)
        {
            if (description == "" || description == null)
                throw new ArgumentException("Description is empty or null");

            if (description.Length > 250)
                throw new ArgumentOutOfRangeException("Description cant be > 250 characters");

        }

        public IEnumerable<Reward> InitList()
        {
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

            _rewardsDAO.Add(reward);
        }

        public void Remove(Reward reward)
        {
            if (reward == null)
                throw new NullReferenceException("Reward is null");

            _rewardsDAO.Remove(reward);
        }

        public void Edit(Reward mainReward, Reward tempReward)
        {
            if (mainReward == null)
                throw new NullReferenceException("Main Reward is null");

            if (tempReward == null)
                throw new NullReferenceException("Temp Reward is null");

            ValidateTitle(tempReward.Title);
            ValidateDescription(tempReward.Description);

            _rewardsDAO.Edit(mainReward, tempReward);
        }

        public IEnumerable<Reward> GetRewards()
        {
            return _rewardsDAO.GetRewards();
        }

        public void SortRewardByTitleAsc()
        {
            (from s in GetRewards()
             orderby s.Title ascending
             select s).ToList();
        }

        public void SortRewardByTitleDesc()
        {
            (from s in GetRewards()
             orderby s.Title descending
             select s).ToList();
        }

        public void SortRewardByIDAsc()
        {
            (from s in GetRewards()
             orderby s.Description ascending
             select s).ToList();
        }

        public void SortRewardByIDDesc()
        {
            (from s in GetRewards()
             orderby s.Description descending
             select s).ToList();
        }
    }
}
