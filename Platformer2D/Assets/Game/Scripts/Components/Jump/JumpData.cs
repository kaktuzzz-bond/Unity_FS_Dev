using System;
using UnityEngine;

namespace Game.Scripts.Components.Jump
{
    [Serializable]
    public class JumpData
    {
        [field: SerializeField]
        public Rigidbody2D Rigidbody { get; private set; }
        
        [field: SerializeField]
        public float Height { get; private set; } = 5;

        [field: SerializeField]
        public float FallGravityScale { get; private set; } = 3;
    }
}