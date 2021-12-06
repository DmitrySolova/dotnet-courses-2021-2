using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IRewardBL
    {
        public void ValidateTitle(string title);

        public void ValidateDescription(string description);

        public void Add(string title, string description);

        public void Add(Reward reward);

        public void Remove(Reward reward);

        public void Edit(Reward mainReward, Reward tempReward);

        public IEnumerable<Reward> GetRewards();

    }
}