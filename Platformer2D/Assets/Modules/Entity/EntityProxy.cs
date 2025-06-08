using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Modules
{
    [RequireComponent(typeof(Collider2D))]
    public class EntityProxy : MonoBehaviour, IEntityProxy
    {
        [Inject, ShowInInspector, HideInEditorMode]
        public IEntity Entity { get; }

        public event Action<IEntity> OnTriggerEnter;
        public event Action<IEntity> OnTriggerExit;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<IEntityProxy>(out var proxy)) return;
            OnTriggerEnter?.Invoke(proxy.Entity);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent<IEntityProxy>(out var proxy)) return;
            OnTriggerExit?.Invoke(proxy.Entity);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.collider.TryGetComponent<IEntityProxy>(out var proxy)) return;
            OnTriggerEnter?.Invoke(proxy.Entity);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.collider.TryGetComponent<IEntityProxy>(out var proxy)) return;
            OnTriggerExit?.Invoke(proxy.Entity);
        }
    }
}