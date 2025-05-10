using Game.Scripts.Game.Core.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Game.Core.Impacts.Pusher
{
    public class Pusher : IPusher
    
    {
        private readonly float _pushForce;

        public Pusher(float pushForce)
        {
            _pushForce = pushForce;
        }

        public void Push(IPushableBody pushable, Vector2 direction)
        {
            
            pushable.TakePush(direction * _pushForce);
            
        }
    }
}