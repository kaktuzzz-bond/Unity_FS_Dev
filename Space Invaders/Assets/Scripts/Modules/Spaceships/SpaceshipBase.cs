using System;
using UnityEngine;

namespace Modules.Spaceships
{
    public abstract class SpaceshipBase : MonoBehaviour
    {
        public event Action OnHealthEmpty;
        public event Action<Transform> OnBulletRequired;

        [SerializeField] protected Transform firePoint;
        [SerializeField] protected new Rigidbody2D rigidbody;

        //protected BulletFactory bulletFactory;
        protected Transform target;
        protected Vector2 destination;

        private int _health;
        private float _speed;
        private Action _onHealthEmpty;


        public virtual void Move(Vector2 direction)
        {
            var moveStep = direction * _speed * Time.fixedDeltaTime;
            var targetPosition = rigidbody.position + moveStep;
            rigidbody.MovePosition(targetPosition);
        }

        public virtual void Attack()
        {
            OnBulletRequired?.Invoke(firePoint);
        }

        public virtual void OnDespawn()
        {
            OnHealthEmpty?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health > 0) return;

            _health = 0;

            _onHealthEmpty?.Invoke();
        }

        // public SpaceshipBase SetBulletFactory(BulletFactory factory)
        // {
        //     bulletFactory = factory;
        //     return this;
        // }

        public SpaceshipBase SetTarget(Transform newTarget)
        {
            target = newTarget;
            return this;
        }

        public SpaceshipBase SetDestination(Vector2 targetPosition)
        {
            destination = targetPosition;
            return this;
        }

        public SpaceshipBase SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
            return this;
        }

        public SpaceshipBase SetHealth(int health)
        {
            _health = health;
            return this;
        }

        public SpaceshipBase SetParent(Transform parent)
        {
            transform.SetParent(parent);
            return this;
        }

        public SpaceshipBase SetSpeed(float speed)
        {
            _speed = speed;
            return this;
        }

        public SpaceshipBase SetTag(string unitTag)
        {
            gameObject.tag = unitTag;
            return this;
        }

        public SpaceshipBase SetActive(bool makeActive)
        {
            gameObject.SetActive(makeActive);
            return this;
        }

        public SpaceshipBase SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
            return this;
        }

        public SpaceshipBase SetActionOnHealthEmpty(Action action)
        {
            action += () => SetActive(false);
            _onHealthEmpty = action;
            return this;
        }
    }
}