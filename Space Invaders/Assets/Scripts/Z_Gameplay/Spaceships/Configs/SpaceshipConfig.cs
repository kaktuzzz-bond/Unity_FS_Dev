using Modules.Extensions;
using UnityEngine;

namespace Z_Gameplay.Spaceships.Configs
{
    [CreateAssetMenu(fileName = "NewSpaceship", menuName = "Space Invaders/Spaceship", order = 0)]
    public class SpaceshipConfig : ScriptableObject
    {
        [SerializeField] private Parameters.Movement movement;
        [SerializeField] private Parameters.Health health;
        [Space] 
        [SerializeField] private WeaponConfig weaponConfig;
        [Space] 
        [SerializeField] private LayerMask layerMask;

        public int CollisionLayer => layerMask.LayerMaskToInt();

        public Spaceship Setup(Spaceship spaceship)
        {
            return spaceship;
        }
    }
}