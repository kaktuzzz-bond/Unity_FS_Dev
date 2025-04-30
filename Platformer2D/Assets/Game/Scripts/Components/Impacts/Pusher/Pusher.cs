using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pusher
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