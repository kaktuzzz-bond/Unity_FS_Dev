using System;
using Gameplay.Spaceships.Components;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public sealed class Spaceship : MonoBehaviour
    {
        public event Action<Spaceship> OnDied;
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private AttackComponent attackComponent;
        [SerializeField] private CollisionDataComponent collisionDataComponent;

        //spaceship config ADD
        private void Awake()
        {
            SetLayerMask();
            healthComponent.ResetHealth();
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
            healthComponent.ResetHealth();
        }

        private void SetLayerMask() =>
            gameObject.layer = collisionDataComponent.CollisionLayer;
    }
}