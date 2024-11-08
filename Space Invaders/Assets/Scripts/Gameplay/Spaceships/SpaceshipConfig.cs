using UnityEngine;

namespace Gameplay.Spaceships
{
    [CreateAssetMenu(fileName = "NewSpaceshipConfig", menuName = "Gameplay/SpaceshipConfig")]
    public class SpaceshipConfig : ScriptableObject
    {
        [Header("Health Settings")]
        public int maxHealth = 5;
        public int startHealth = 5;

        [Header("Movement Settings")]
        public float speed = 5;
        
        [Header("Collision Settings")]
        public LayerMask layerMask;
    }
}