using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Player
{
    [CreateAssetMenu(fileName = "EntitySettings", menuName = "Game/Entity Settings", order = 0)]
    public class EntityConfig : ScriptableObject
    {
        [Title("Settings")]
        [SerializeField]
        private float moveSpeed = 5;

        [SerializeField]
        private float jumpForce = 10;

        [SerializeField]
        private int maxHealth = 10;

        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;
        public int MaxHealth => maxHealth;
    }
}