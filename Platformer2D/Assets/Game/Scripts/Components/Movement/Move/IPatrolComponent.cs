using System;
using UnityEngine;

namespace Game.Scripts.Components.Movement.Move
{
    public interface IPatrolComponent
    {
        Vector3 Direction { get; }

        public bool IsNear { get; }
        void MoveNext();
    }
}