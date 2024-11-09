using Gameplay.Spaceships;
using Gameplay.Weapon;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerCreator : MonoBehaviour
    {
        [SerializeField] private Spaceship prefab;
        [SerializeField] private Transform parent;

        public ISpaceship Create(SpaceshipConfig spaceshipConfig, BulletSpawner bulletSpawner)
        {
            var spaceship = Instantiate(prefab, parent);
            spaceship.Construct(spaceshipConfig, bulletSpawner);
            return spaceship;
        }
    }
}