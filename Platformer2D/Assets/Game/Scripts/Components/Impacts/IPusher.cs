using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public interface IPusher
    {
        void Push(IPushable pushable);
        void Push(IPushable pushable, Vector3 force);
    }
}