using Modules.Extensions;
using UnityEngine;
using Z_Gameplay.Spaceships.Components;

namespace Z_Gameplay.Spaceships.Configs
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Space Invaders/Weapon", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        public Sprite sprite;
        public Color color;
        public float projectileSpeed = 3;
        public int projectileDamage = 1;

        [SerializeField] private LayerMask layerMask;

        public int CollisionLayer => layerMask.LayerMaskToInt();

        public AttackComponent Create()
        {
            return new AttackComponent();
        }
    }
}