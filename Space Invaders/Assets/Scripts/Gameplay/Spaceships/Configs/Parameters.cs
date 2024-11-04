using System;

namespace Gameplay.Spaceships.Configs
{
    public class Parameters
    {
        [Serializable]
        public class Movement
        {
            public float speed;
        }

        [Serializable]
        public class Health
        {
            public int maxHealth;
            public int startHealth;
        }
    }
}