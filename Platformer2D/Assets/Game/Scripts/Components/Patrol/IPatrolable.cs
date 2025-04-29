using UnityEngine;

namespace Game.Scripts.Components.Patrol
{
    public interface IPatrolable
    {
        Vector3 Direction { get; }

        public bool IsNear { get; }
        void MoveNext();
    }
}