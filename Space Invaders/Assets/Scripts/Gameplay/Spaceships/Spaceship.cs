using System;
using Gameplay.Spaceships.Weapon;
using Modules.Extensions;
using Modules.Spaceships.Health;
using Modules.Spaceships.Movement;
using Modules.Spaceships.Weapon;
using UnityEngine;

namespace Gameplay.Spaceships
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Spaceship : MonoBehaviour
    {
        public event Action<Spaceship> OnDeath;
        public event Action<Vector2, Vector2> OnFire;

        [SerializeField] private SpaceshipConfig config;
        [SerializeField] private Transform firePoint;

        private IHealthService _healthService;
        private IMoveService _moveService;
        private IWeaponService _weaponService;


        private void Awake()
        {
            _healthService = new HealthService(config.maxHealth, config.startHealth);
            _moveService = new Rigidbody2DMover(GetComponent<Rigidbody2D>(), config.speed);
            gameObject.layer = config.layerMask.LayerMaskToInt();
        }

        public void SetWeapon(BulletSpawner bulletSpawner)
        {
            _weaponService = new BulletWeapon(firePoint, bulletSpawner);
        }

        private void OnEnable()
        {
            _healthService.OnDied += Die;
        }

        public void Reset()
        {
            _healthService.ResetHealth();
        }

        public void Move(Vector2 direction)
        {
            _moveService.Move(direction);
        }

        public void Attack()
        {
            _weaponService.Attack(Vector2.up);
        }

        public void Attack(Vector2 direction)
        {
            _weaponService.Attack(direction);
        }

        public void TakeDamage(int damage)
        {
            _healthService.TakeDamage(damage);
        }

        private void Die()
        {
            OnDeath?.Invoke(this);
        }

        private void OnDisable()
        {
            _healthService.OnDied -= Die;
        }
    }
}