using UnityEditor;
using UnityEngine;

namespace Gameplay.Spaceships
{
    [CreateAssetMenu(fileName = "NewSpaceshipData", menuName = "SpaceInvaders/SpaceshipData", order = 1)]
    public class SpaceshipData : ScriptableObject
    {
        public enum SpaceshipType
        {
            Enemy,
            Player
        }

        [Header("Type")]
        public SpaceshipType spaceshipType;
        [Header("Health")]
        [Min(0)] public int maxHealth;
        [Min(0)] public int startHealth;
        [Header("Speed")] 
        [Min(0)] public float speed;
        [Header("Attack")] 
        [Min(0)] public float attackCooldown;
        [Header("Collisions")]
        public LayerMask layerMask;
    }
}