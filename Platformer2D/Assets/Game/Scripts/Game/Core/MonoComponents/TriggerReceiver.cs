using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.MonoComponents
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerReceiver : MonoBehaviour, ITriggerReceiver
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;
        private void OnTriggerEnter2D(Collider2D other) => OnTriggerEnter?.Invoke(other);

        private void OnTriggerExit2D(Collider2D other) => OnTriggerExit?.Invoke(other);

        private void OnCollisionEnter2D(Collision2D other) => OnTriggerEnter?.Invoke(other.collider);

        private void OnCollisionExit2D(Collision2D other) => OnTriggerExit?.Invoke(other.collider);
    }
}