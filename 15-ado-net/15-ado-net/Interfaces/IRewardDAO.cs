using Entities;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRewardDAO
    {
        public void Add(Reward reward);

        public void ClearAndCopyRange(IEnumerable<Reward> rewards);
        public void Remove(Reward reward);

        public void Clear();

        public void Edit(Reward mainReward, Reward tempReward);

        IEnumerable<Reward> GetRewards();
    }
}
