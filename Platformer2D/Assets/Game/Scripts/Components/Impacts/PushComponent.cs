using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public class PushComponent : IPusher
    {
        private readonly Vector3 _defaultForce;

        public PushComponent(Vector3 defaultForce)
        {
            _defaultForce = defaultForce;
        }

        public void Push(IPushable pushable)
        {
            pushable.TakePush(_defaultForce);
        }

        public void Push(IPushable pushable, Vector3 force)
        {
            pushable.TakePush(force);
        }
    }
}