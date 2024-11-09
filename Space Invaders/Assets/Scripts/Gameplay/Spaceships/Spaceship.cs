using System;
using Gameplay.Spaceships.Strategy;
using Gameplay.Weapon;
using Modules.Spaceships.Health;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour
    {
        public event Action<Spaceship> OnDeath;

        [SerializeField] private Transform firePoint;
        [SerializeField] private new Rigidbody2D rigidbody2D;

        private IHealthService _healthService;
        private IAIStrategy _moveStrategy;
        private IAIStrategy _attackStrategy;


        public void Construct(SpaceshipConfig config, BulletSpawner bulletSpawner)
        {
            _healthService = config.HealthService;
            _moveStrategy = new MoveStrategy(rigidbody2D, config.Speed);
            _attackStrategy = new AttackStrategy(firePoint, bulletSpawner);
            gameObject.layer = config.CollisionLayer;
        }

        public void OnActivate()
        {
            _healthService.OnHealthEmpty += Die;
            _healthService.ResetHealth();
        }

        public void Move(Vector2 direction)
        {
            _moveStrategy.Update(direction);
        }

        public void Attack(Vector2 direction)
        {
            _attackStrategy.Update(direction);
        }

        public void TakeDamage(int damage)
        {
            _healthService.TakeDamage(damage);
        }


        public void OnDeactivate()
        {
            _healthService.OnHealthEmpty -= Die;
        }

        private void Die()
        {
            OnDeath?.Invoke(this);
        }
    }
}