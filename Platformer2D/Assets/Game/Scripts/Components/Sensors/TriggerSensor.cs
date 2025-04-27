using System;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public class TriggerSensor : MonoBehaviour, ITriggerSensor
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;
        private void OnTriggerEnter2D(Collider2D other) => OnTriggerEnter?.Invoke(other);

        private void OnTriggerExit2D(Collider2D other) => OnTriggerExit?.Invoke(other);
    }
}