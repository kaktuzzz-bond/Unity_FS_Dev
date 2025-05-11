using UnityEngine;
using Zenject;

namespace Game.Scripts.Game.Core.Health
{
    public class HealthProxy : MonoBehaviour, IDamagable
    {
        private IHealthComponent _healthComponent;

        [Inject]
        private void Construct(IHealthComponent healthComponent)
        {
            _healthComponent = healthComponent;
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }
    }
}