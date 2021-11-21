using Entities;
using Interfaces;
using System;
using System.Collections.Generic;

namespace DAL.List
{
    public class RewardsListDAO : IRewardDAO
    {
        private List<Reward> _rewardsList = new List<Reward>();
        public void Add(Reward reward)
        {
            if (reward is null)
                throw new NullReferenceException("Reward is null");

            _rewardsList.Add(reward);
        }
        public void ClearAndCopyRange(IEnumerable<Reward> rewards)
        {
            Clear();

            foreach (var reward in rewards)
            {
                _rewardsList.Add(reward);
            }
        }
        public void Clear()
        {
            _rewardsList.Clear();
        }

        public void Remove(Reward reward)
        {
            if (reward is null)
                throw new NullReferenceException("Reward is null");

            _rewardsList.Remove(reward);
        }

        public IEnumerable<Reward> GetRewards()
        {
            return _rewardsList;
        }

        public void EditTitle(Reward reward, string newTitle)
        {
            int index = _rewardsList.FindIndex((rewardToFind) => rewardToFind.Equals(reward));

            if (index == -1)
                throw new Exception("Cant find element");
            _rewardsList[index].Title = newTitle;
        }

        public void EditDescription(Reward reward, string newDescription)
        {
            int index = _rewardsList.FindIndex((rewardToFind) => rewardToFind.Equals(reward));

            if (index == -1)
                throw new Exception("Cant find element");

            _rewardsList[index].Description = newDescription;
        }
    }
}
