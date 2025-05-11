using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    [Serializable]
    public class ForceData
    {
        [SerializeField]
        public Vector2 direction = Vector2.up;

        [SerializeField, Min(0)]
        public float force = 1;

        public Vector2 Force => direction * force;
    }
}