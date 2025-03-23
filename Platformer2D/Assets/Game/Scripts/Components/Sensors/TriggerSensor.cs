using System;
using Game.Scripts.Components.Health;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerSensor : MonoBehaviour, ITriggerProxy
    {
        public event Action<IDamagable> OnTriggered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<ITriggerProxy>(out _)) return;

            CheckForDamagableRoot(other.transform);
        }


        private void CheckForDamagableRoot(Transform proxy)
        {
            var parent = proxy.parent;

            if (parent == null) return;

            if (parent.TryGetComponent<IDamagable>(out var target))
            {
                OnTriggered?.Invoke(target);
            }
        }
    }
}