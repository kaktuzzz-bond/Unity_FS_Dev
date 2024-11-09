using Gameplay.Weapon;
using Modules.Extensions;
using Modules.Spaceships.Health;
using UnityEngine;

namespace Gameplay.Spaceships
{
    [CreateAssetMenu(fileName = "NewSpaceshipConfig", menuName = "Gameplay/SpaceshipConfig")]
    public class SpaceshipConfig : ScriptableObject
    {
        [Header("Health Settings")] [SerializeField]
        private int maxHealth = 5;

        [SerializeField] private int startHealth = 5;

        [Header("Movement Settings")] [SerializeField]
        private float speed = 5;

        [Header("Collision Settings")] [SerializeField]
        private LayerMask layerMask;

        public HealthService HealthService { get; private set; }

        public int CollisionLayer => layerMask.LayerMaskToInt();
        public float Speed => speed;

        public SpaceshipConfig()
        {
            HealthService = new HealthService(maxHealth, startHealth);
        }
    }
}