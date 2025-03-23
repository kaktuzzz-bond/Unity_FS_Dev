using System;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Trap
{
    public class Trap : MonoBehaviour, IDamagable
    {
        [SerializeField, Min(0)]
        private int attackDamage = 1;

        private IHealthComponent _healthComponent;

        private ITriggerProxy _triggerProxy;

        [Inject]
        public void Construct(IHealthComponent healthComponent, ITriggerProxy triggerProxy)
        {
            _healthComponent = healthComponent;
            _triggerProxy = triggerProxy;
        }

        private void OnEnable()
        {
            _triggerProxy.OnTriggered += OnTargetCaught;
        }

        private void OnTargetCaught(IDamagable target)
        {
            target.TakeDamage(attackDamage);
            gameObject.SetActive(false);
        }

        public void TakeDamage(int damage) => _healthComponent.TakeDamage(damage);

        private void OnDisable()
        {
            _triggerProxy.OnTriggered -= OnTargetCaught;
        }
    }
}