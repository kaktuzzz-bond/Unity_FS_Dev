using System;
using UnityEngine;

namespace Game.Scripts.Components.Movement
{
    [Serializable]
    public class MovementData
    {
        [field: SerializeField]
        public Rigidbody2D Rigidbody { get; private set; }

        [field: SerializeField]
        public Transform Body { get; private set; }

        [field: SerializeField]
        public float Speed { get; private set; } = 5;

        [field: SerializeField]
        public bool IsFlippable { get; private set; } = true;
    }
}