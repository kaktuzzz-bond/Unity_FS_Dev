using System;
using Game.Scripts.Components.Health;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    [InfoBox("A Parent object should have IDamagable component to be detected as a hit target")]
    public class TriggerSensor : MonoBehaviour, ITriggerProxy
    {
        public event Action<IDamagable> OnTriggered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<ITriggerProxy>(out _)) return;

            var parent = other.transform.parent;

            if (parent == null) return;

            if (!parent.TryGetComponent<IDamagable>(out var target)) return;

            Debug.LogWarning($"{gameObject.name} catched {target.GetType().Name}");

            OnTriggered?.Invoke(target);
        }
    }
}