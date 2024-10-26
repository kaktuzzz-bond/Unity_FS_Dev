using System;
using Gameplay.Bullets;
using Gameplay.Spaceships.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour
    {
        public event Action OnHealthEmpty;
        public event Action<Transform> OnBulletRequired;

       
        [SerializeField] protected MoveComponent moveComponent;
        [SerializeField] protected HealthComponent healthComponent; 
        [SerializeField] protected AttackComponent attackComponent; 
        
        [SerializeField] protected CollisionDataComponent collisionDataComponent; 


        protected Transform target;
        protected Vector2 destination;


        private Action _onHealthEmpty;
       

        public virtual void Move(Vector2 direction)
        {
            moveComponent.Move(direction);
        }

        public virtual void Attack()
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


        public Spaceship SetTarget(Transform newTarget)
        {
            target = newTarget;
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


        public Spaceship SetParent(Transform parent)
        {
            transform.SetParent(parent);
            return this;
        }


        public Spaceship SetTag(string unitTag)
        {
            gameObject.tag = unitTag;
            return this;
        }

        public Spaceship SetActive(bool makeActive)
        {
            gameObject.SetActive(makeActive);
            return this;
        }

        public Spaceship SetPhysicsLayer(int physicsLayer)
        {
            gameObject.layer = physicsLayer;
            return this;
        }

        public Spaceship SetActionOnHealthEmpty(Action action)
        {
            action += () => SetActive(false);
            _onHealthEmpty = action;
            return this;
        }
    }
}