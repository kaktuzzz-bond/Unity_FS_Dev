using System;

namespace Gameplay.Enemy
{
    [Serializable]
    public class EnemySpawnSettings
    {
        public float minSpawnDelay = 1f;
        public float maxSpawnDelay = 2f;
        public int maxActiveEnemies = 4;
    }
}