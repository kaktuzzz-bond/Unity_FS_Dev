using Game.Scripts.Components.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public interface IPusher
    {
        void Push(IPushable pushable, Vector2 direction);
    }
}