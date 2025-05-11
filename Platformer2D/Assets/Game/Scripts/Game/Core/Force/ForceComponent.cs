using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    [Serializable]
    public class ForceComponent : IForceComponent
    {
        [SerializeField]
        private Rigidbody2D rigidbody;
        
        public void AddForce(Vector2 force)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}