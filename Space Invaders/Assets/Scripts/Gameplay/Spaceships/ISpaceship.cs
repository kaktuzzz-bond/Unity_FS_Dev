using System;
using Gameplay.Weapon;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public interface ISpaceship
    {
        event Action<ISpaceship> OnDeath;
        void Construct(SpaceshipConfig config, BulletSpawner bulletSpawner);
        void SetPositionAndRotation(Vector3 position, Quaternion rotation);
        void OnActivate();
        void Move(Vector2 direction);
        void Attack(Vector2 direction);
        void TakeDamage(int damage);
        void OnDeactivate();
    }
}