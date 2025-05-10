using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Core.Health
{
    [Serializable]
    public class HealthComponent : IHealthComponent, IInitializable
    {
        [SerializeField, Min(0)]
        private int maxHealth = 1;

        public event Action OnDeath;
        public event Action<float> OnHealthChanged;

        [ShowInInspector, ReadOnly]
        public float HealthLevel => (float)_currentHealth / maxHealth;

        [ShowInInspector, ReadOnly]
        public bool IsAlive => _currentHealth > 0;


        private int _currentHealth;

        public void Initialize()
        {
            RestoreHealth();
        }


        [Button, HideInEditorMode]
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (IsAlive) return;

            Kill();
        }

        [Button, HideInEditorMode]
        public void Kill()
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
        }

        [Button, HideInEditorMode]
        public void RestoreHealth()
        {
            _currentHealth = maxHealth;
        }
    }
}