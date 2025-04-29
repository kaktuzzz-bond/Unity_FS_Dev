using System;
using UnityEngine;

namespace Game.Scripts.Components.Health
{
    [RequireComponent(typeof(Collider2D))]
    public class DamagableBody : MonoBehaviour, IDamagableBody
    {
        public event Action<int> OnDamageTaken;
        
        public void TakeDamage(int damage)
        {
            OnDamageTaken?.Invoke(damage);
        }
    }
}