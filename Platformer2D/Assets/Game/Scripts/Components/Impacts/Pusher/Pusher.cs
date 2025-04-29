using Game.Scripts.Components.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public class Pusher : IPusher
    {
        public void Push(IPushable pushable, Vector2 direction)
        {
            pushable.TakePush(direction);
        }
    }
}