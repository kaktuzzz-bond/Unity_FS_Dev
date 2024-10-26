using System;
using Gameplay.Bullets;
using Gameplay.Spaceships.Components;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour
    {
        public event Action OnHealthEmpty;

        [SerializeField] protected MoveComponent moveComponent;
        [SerializeField] protected HealthComponent healthComponent;
        [SerializeField] protected AttackComponent attackComponent;
        [SerializeField] protected CollisionDataComponent collisionDataComponent;

        protected Vector2 destination;

        private Action _onHealthEmpty;

        private void Awake()
        {
            SetLayerMask();
        }


        public virtual void Move(Vector2 direction)
        {
            moveComponent.Move(direction);
        }

        public void Attack()
        {
            attackComponent.Attack();
        }

        public void TakeDamage(int damage)
        {
            healthComponent.TakeDamage(damage);
        }

        public virtual void OnDespawn()
        {
            OnHealthEmpty?.Invoke();
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

        public Spaceship SetDestination(Vector2 targetPosition)
        {
            destination = targetPosition;
            return this;
        }

        public Spaceship SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
            return this;
        }


        public Spaceship SetActive(bool makeActive)
        {
            gameObject.SetActive(makeActive);
            return this;
        }


        private void SetLayerMask() =>
            gameObject.layer = collisionDataComponent.CollisionLayer;
    }
}