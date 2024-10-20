using Modules.Bullets;
using Modules.Factories;
using Modules.Spaceships;
using UnityEngine;

namespace Gameplay
{
    public class FactoryController : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Enemy enemyPrefab;
        [Header("Parents")]
        [SerializeField] private Transform bulletParent;
        [SerializeField] private Transform playerParent;
        [SerializeField] private Transform enemyParent;
        
        public SpaceshipFactory SpaceshipFactory { get; private set; }
        
        private BulletFactory _bulletFactory;
        public void Initialize()
        {
            _bulletFactory = new BulletFactory(bulletPrefab, bulletParent);
            SpaceshipFactory =
                new SpaceshipFactory(playerPrefab, enemyPrefab, playerParent, enemyParent, _bulletFactory);
        }
    }
}