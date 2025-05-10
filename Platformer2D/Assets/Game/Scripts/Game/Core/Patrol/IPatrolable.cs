using UnityEngine;

namespace Game.Scripts.Game.Core.Patrol
{
    public interface IPatrolable
    {
        Vector3 Direction { get; }

        public bool IsNear { get; }
        void MoveNext();
    }
}