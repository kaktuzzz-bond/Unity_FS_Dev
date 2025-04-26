using System;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Sensors;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Enemies.Trap
{
    public class TrapView : MonoBehaviour, IDamagable
    {
        // [SerializeField]
        // private TriggerSensor triggerProxy;

        [Inject]
        private ITrap _trap;

        private void OnEnable()
        {
            //triggerProxy.OnTriggered += OnTargetCaught;
            _trap.OnDead += Die;
        }

        private void Die() => 
            gameObject.SetActive(false);

        private void OnTargetCaught(IDamagable target)
        {
            _trap.Attack(target);
            Die();
        }

        public void TakeDamage(int damage)
        {
            _trap.TakeDamage(damage);
        }


        private void OnDisable()
        {
            //triggerProxy.OnTriggered -= OnTargetCaught;
            _trap.OnDead -= Die;
        }
    }
}