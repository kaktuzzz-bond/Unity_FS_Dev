using System;
using Game.Scripts.Game.Core.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Game.Core.Impacts
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