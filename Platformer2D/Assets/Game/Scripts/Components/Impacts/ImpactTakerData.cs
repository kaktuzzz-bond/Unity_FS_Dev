using System;
using Game.Scripts.Components.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    [Serializable]
    public class ImpactTakerData
    {
        [field: SerializeField]
        public Rigidbody2D Rigidbody { get; private set; }
        
        [field: SerializeField]
        public PushableBody Body { get; private set; }
    }
}