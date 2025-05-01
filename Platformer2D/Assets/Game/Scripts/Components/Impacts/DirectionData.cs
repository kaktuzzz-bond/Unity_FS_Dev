using System;
using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    [Serializable]
    public class DirectionData
    {
        [SerializeField]
        public Vector2 direction = Vector2.up;

        public Vector2 Direction => direction;
        public Vector2 NormalizedDirection => direction.normalized;
    }
}