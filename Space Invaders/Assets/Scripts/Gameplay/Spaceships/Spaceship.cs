using System;
using Gameplay.Spaceships.Components;
using Gameplay.Weapon;
using Modules.Pooling;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, IPoolReleasable<Spaceship>
    {
        public event Action<Spaceship> OnDied;
        [SerializeField] protected MoveComponent moveComponent;
        [SerializeField] protected HealthComponent healthComponent;
        [SerializeField] protected AttackComponent attackComponent;
        [SerializeField] protected CollisionDataComponent collisionDataComponent;


        public Action<Spaceship> OnRelease { get; set; }

        private void Awake()
        {
            SetLayerMask();
        }

        private void OnEnable()
        {
            healthComponent.OnHealthEmpty += Despawn;
        }

        private void OnDisable()
        {
            healthComponent.OnHealthEmpty -= Despawn;
        }

        public void Move(Vector2 direction) =>
            moveComponent.Move(direction);

        public void Attack() =>
            attackComponent.Attack();

        public void TakeDamage(int damage) =>
            healthComponent.TakeDamage(damage);


        public void SetReleaseAction(Action<Spaceship> action)
        {
            OnRelease = action;
        }


        public Spaceship SetWeapon(IWeapon weapon)
        {
            attackComponent.SetWeapon(weapon);
            return this;
        }

        public Spaceship SetTarget(Transform target)
        {
            attackComponent.SetTarget(target);
            return this;
        }

        public Spaceship SetActive(bool makeActive)
        {
            gameObject.SetActive(makeActive);
            return this;
        }

        private void Despawn()
        {
            OnDied?.Invoke(this);
            OnRelease.Invoke(this);
        }

        private void SetLayerMask() =>
            gameObject.layer = collisionDataComponent.CollisionLayer;
    }
}