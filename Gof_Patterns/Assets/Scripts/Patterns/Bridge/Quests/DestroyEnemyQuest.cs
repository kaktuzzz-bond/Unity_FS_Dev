using Patterns.Bridge.Rewards;
using UnityEngine;

namespace Patterns.Bridge.Quests
{
    public class DestroyEnemyQuest : Quest
    {
        private int _enemyCount;
        private Character _character;
        public DestroyEnemyQuest(
            string title, 
            Sprite icon, 
            IReward reward, 
            Character character, 
            int enemyCount) : base(title, icon, reward)
        {
            _character = character;
            _enemyCount = enemyCount;
        }

        public override void StartQuest()
        {
        }

        public override void StopQuest()
        {
        }
    }
}