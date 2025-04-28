using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public class PushableComponent : IPushable
    {
        private readonly Rigidbody2D _rigidbody;

        public PushableComponent(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void TakePush(Vector3 force)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}