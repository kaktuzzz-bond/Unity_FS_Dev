using System;
using UnityEngine;

namespace Modules.Enemies
{
    public abstract class UnitBase : MonoBehaviour
    {
        public event Action<UnitBase> OnDeath;
            
        [SerializeField] protected Transform firePoint;

        [SerializeField] protected new Rigidbody2D rigidbody;

        [SerializeField] protected int health;

        [SerializeField] protected float speed = 5.0f;

        public abstract void Move(Vector2 direction);

        public abstract void Attack();

        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            
            if (health > 0) return;
            
            health = 0;
            OnDeath?.Invoke(this);
        }
    }
}