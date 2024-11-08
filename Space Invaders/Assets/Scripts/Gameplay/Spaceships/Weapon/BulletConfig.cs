using UnityEngine;

namespace Gameplay.Spaceships.Weapon
{
    [CreateAssetMenu(fileName = "NewBulletConfig", menuName = "Gameplay/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [Header("Appearance Settings")]
        public Sprite sprite;
        public Color color = Color.white;
        
        [Header("Damage Settings")]
        public int damage = 1;

        [Header("Movement Settings")]
        public float speed = 3;
        
        [Header("Collision Settings")]
        public LayerMask layerMask;
    }
}