using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    [Serializable]
    public class ForceData
    {
        [SerializeField]
        private Vector2 direction = Vector2.one;

        [field: SerializeField, Min(0)]
        public float Force { get; private set; } = 1;

        public Vector2 GetForce() => direction.normalized * Force;
        public Vector2 GetForce(Vector2 ownDirection) => ownDirection.normalized * Force;
    }
}