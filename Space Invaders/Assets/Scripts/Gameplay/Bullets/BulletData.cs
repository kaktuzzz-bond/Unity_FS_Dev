using UnityEngine;

namespace Gameplay.Bullets
{
    [CreateAssetMenu(fileName = "NewBulletData", menuName = "SpaceInvaders/BulletData", order = 1)]
    public class BulletData:ScriptableObject
    {
        [Header("View")]
        [Min(0)] public int damage = 1;
        public Color color = Color.white;
        [Header("Collisions")]
        public LayerMask layerMask;
    }
}