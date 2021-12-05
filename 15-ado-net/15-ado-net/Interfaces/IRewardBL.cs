using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRewardBL
    {
        public int GenerateID();

        public void ValidateTitle(string title);

        public void ValidateDescription(string description);

        public IEnumerable<Reward> InitList();

        public void Add(string title, string description);

        public void Add(Reward reward);

        public void Remove(Reward reward);

        public void Edit(Reward mainReward, Reward tempReward);

        public IEnumerable<Reward> GetRewards();

        public void SortRewardByTitleAsc();

        public void SortRewardByTitleDesc();

        public void SortRewardByIDAsc();

        public void SortRewardByIDDesc();
    }
}
