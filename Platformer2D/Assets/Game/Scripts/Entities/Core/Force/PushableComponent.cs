using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class ForceComponent : IPushable
    {
        public event Action OnForceAdded;

        [SerializeField]
        private Rigidbody2D rigidbody;

        public void AddForce(Vector2 force, Vector2 otherPosition)
        {
            var sign = Mathf.Sign(((Vector2)rigidbody.transform.position - otherPosition).x);

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