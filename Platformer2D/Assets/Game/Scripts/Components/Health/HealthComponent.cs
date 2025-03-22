using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components.Health
{
    public interface IHealthComponent
    {
        void TakeDamage(int damage);

        void Restore();
    }


    public class HealthComponent : IHealthComponent
    {
        public int CurrentHealth { get; private set; }

        private readonly int _maxHealth;

        public HealthComponent(int maxHealth, int startHealth)
        {
            if (maxHealth <= 0 || startHealth <= 0)
                throw new ArgumentOutOfRangeException($"Max Health <{maxHealth}> | Start Health <{startHealth}>");

            _maxHealth = maxHealth;
            CurrentHealth = startHealth;
        }

        [Button]
        public void TakeDamage(int damage)
        {
            damage = Mathf.Clamp(damage, 0, CurrentHealth);
            CurrentHealth -= damage;
        }

        [Button]
        public void Restore()
        {
            CurrentHealth = _maxHealth;
        }
    }
}