using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class ForceComponent : IForceComponent
    {
        [SerializeField]
        private Rigidbody2D rigidbody;

        public event Action OnForceAdded;
        public Vector2 Position => rigidbody.transform.position;

        public void AddForce(Vector2 force, Vector2 otherPosition)
        {
            var sign = Mathf.Sign((Position - otherPosition).x);

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