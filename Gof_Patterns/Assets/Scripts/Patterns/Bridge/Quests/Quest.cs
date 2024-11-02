using Patterns.Bridge.Rewards;
using UnityEngine;

namespace Patterns.Bridge.Quests
{
    public abstract class Quest
    {
        public string Title { get; }
        public Sprite Icon { get; }

        private readonly IReward _reward;


        protected Quest(
            string title, 
            Sprite icon, 
            IReward reward)
        {
            Title = title;
            Icon = icon;
            _reward = reward;
        }

        public abstract void StartQuest();
        public abstract void StopQuest();

        public void ApplyReward()
        {
            _reward.Apply();
        }
    }
}