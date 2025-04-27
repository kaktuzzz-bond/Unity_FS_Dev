using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public class PushComponent : IPusher
    {
        private readonly Vector3 _force;

        public PushComponent(Vector3 force)
        {
            _force = force;
        }

        public void Push(IPushable pushable)
        {
            pushable.TakePush(_force);
        }
    }
}