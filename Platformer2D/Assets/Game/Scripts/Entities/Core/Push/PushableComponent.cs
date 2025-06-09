using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class PushableComponent : IPushableComponent
    {
        public event Action OnForceAdded;

        [SerializeField]
        private Rigidbody2D rigidbody;

        public Vector2 GetPosition => rigidbody.position;
        
        public void AddForce(Vector2 force, Vector2 otherPosition)
        {
            var sign = Mathf.Sign((GetPosition - otherPosition).x);

            var newForce = new Vector2(sign * force.x, force.y);

            AddForce(newForce);
        }
        

        public void AddForce(Vector2 force)
        {
            OnForceAdded?.Invoke();
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}