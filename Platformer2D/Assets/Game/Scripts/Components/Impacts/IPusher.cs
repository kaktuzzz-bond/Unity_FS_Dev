using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public interface IPusher
    {
        void Push(IPushable pushable, Vector2 direction);
    }
}