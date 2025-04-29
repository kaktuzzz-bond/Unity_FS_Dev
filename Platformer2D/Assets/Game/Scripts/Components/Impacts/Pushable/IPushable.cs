using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pushable
{
    public interface IPushable
    {
        void TakePush(Vector3 force);
    }
}