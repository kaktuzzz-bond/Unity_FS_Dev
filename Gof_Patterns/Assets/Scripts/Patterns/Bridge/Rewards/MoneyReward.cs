using Patterns.Bridge.Storage;

namespace Patterns.Bridge.Rewards
{
    public class MoneyReward : IReward
    {
        private readonly MoneyStorage _moneyStorage;
        private readonly int _reward;

        public MoneyReward(MoneyStorage moneyStorage, int reward)
        {
            _moneyStorage = moneyStorage;
            _reward = reward;
        }
        public void Apply()
        {
           _moneyStorage.AddMoney(_reward);
        }
        
    }
}