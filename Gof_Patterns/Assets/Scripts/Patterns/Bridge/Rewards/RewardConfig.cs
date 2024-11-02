using UnityEngine;

namespace Patterns.Bridge.Rewards
{
    public abstract class RewardConfig : ScriptableObject
    {
        public abstract IReward Create();
    }
}