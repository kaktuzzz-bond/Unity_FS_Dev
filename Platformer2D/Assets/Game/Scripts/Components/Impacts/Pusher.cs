using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public class Pusher : IPusher

    {
        public void Push(IPushable pushable, Vector2 direction)
        {
            pushable.TakePush(direction);
        }
    }
}