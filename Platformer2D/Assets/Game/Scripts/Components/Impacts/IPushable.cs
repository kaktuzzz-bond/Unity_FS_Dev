using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public interface IPushable
    {
        void TakePush(Vector3 force);
    }
}