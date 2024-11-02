using Patterns.Bridge.Rewards;
using UnityEngine;

namespace Patterns.Bridge.Quests
{
    public abstract class QuestConfig : ScriptableObject
    {
        [SerializeField] protected string title;
        [SerializeField] protected Sprite icon;
        [SerializeField] protected RewardConfig rewardConfig;

        public abstract Quest Create();
    }
}