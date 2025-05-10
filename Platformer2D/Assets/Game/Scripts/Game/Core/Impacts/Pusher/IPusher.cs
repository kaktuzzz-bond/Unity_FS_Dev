using Game.Scripts.Game.Core.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Game.Core.Impacts.Pusher
{
    public interface IPusher
    {
        void Push(IPushableBody pushable, Vector2 direction);
    }
}