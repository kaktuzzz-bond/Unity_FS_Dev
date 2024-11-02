using Patterns.Bridge.Rewards;
using UnityEngine;

namespace Patterns.Bridge.Quests
{
    public class DestroyEnemyConfig:QuestConfig
    {
        [SerializeField] private int enemyCount;
        
        //[Inject]
        private Character _character;
        public override Quest Create()
        {
            IReward reward = rewardConfig.Create();

            return new DestroyEnemyQuest(title, icon, reward, _character, enemyCount);
        }
    }
}