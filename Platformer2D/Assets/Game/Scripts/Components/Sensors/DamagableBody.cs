using System;
using Game.Scripts.Components.Health;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public class DamagableBody : MonoBehaviour, IDamagableBody
    {
        public event Action<int> OnDamageTaken;

        public void TakeDamage(int damage)
        {
            OnDamageTaken?.Invoke(damage);
        }
    }
}