using System;
using UnityEngine;

namespace Gameplay.Spaceships.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnHealthEmpty;
        [SerializeField] private int maxHealth;
        [SerializeField] private int startHealth;

        [SerializeField] private int _health;


        public void ResetHealth() => 
            SetHealth(startHealth);


        public void TakeDamage(int damage)
        {
            SetHealth(_health - damage);

            if (_health == 0)
                OnHealthEmpty?.Invoke();
        }

        private void SetHealth(int health)
        {
            _health = Mathf.Clamp(health, 0, maxHealth);
        }
    }
}