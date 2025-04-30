using System;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pushable
{
    public class PushTaker : IPushable, IInitializable, IDisposable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly IPushableBody _body;

        public PushTaker(Rigidbody2D rigidbody, IPushableBody body)
        {
            _rigidbody = rigidbody;
            _body = body;
        }

        public void Initialize()
        {
            _body.OnImpacted += TakePush;
        }


        public void TakePush(Vector3 force)
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        public void Dispose()
        {
            _body.OnImpacted -= TakePush;
        }
    }
}