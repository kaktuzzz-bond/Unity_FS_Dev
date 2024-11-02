using Patterns.Bridge.Storage;
using UnityEngine;

namespace Patterns.Bridge.Rewards
{
    public class MoneyRewardConfig : RewardConfig
    {
        //[Inject]
        private MoneyStorage _moneyStorage;
        [SerializeField] private int rewardAmount;

        public override IReward Create()
        {
            return new MoneyReward(_moneyStorage, rewardAmount);
        }
    }
}