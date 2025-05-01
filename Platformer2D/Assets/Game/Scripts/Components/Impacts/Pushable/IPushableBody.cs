using System;
using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pushable
{
    public interface IPushableBody
    {
        public Vector3 WorldPosition { get; }
        event Action<Vector3> OnImpacted;

        void TakePush(Vector3 force);
    }
}