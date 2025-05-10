using UnityEngine;

namespace Game.Scripts.Game.Core.Impacts.Pushable
{
    public interface IPushable
    {
        void TakePush(Vector3 force);
    }
}