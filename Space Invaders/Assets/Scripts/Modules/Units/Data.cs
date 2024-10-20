using UnityEngine;

namespace Gameplay
{
    public static class Data
    {
        public class Tags
        {
            public const string PlayerTag = "Player";
            public const string EnemyTag = "Enemy";
            public const string BoundTag = "Bound";
        }

        public class Layers
        {
            public const int PlayerSpaceshipLayer = 10;
            public const int EnemySpaceshipLayer = 11;
            public const int EnemyBulletLayer = 13;
            public const int PlayerBulletLayer = 14;
        }
        
        public class Colors
        {
            public static Color EnemyBulletColor => Color.red;
            public static Color PlayerBulletColor => Color.blue;
        }
    }
}