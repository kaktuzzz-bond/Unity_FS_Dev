using System;
using UnityEngine;

namespace Game.Scripts.Components.Health
{
    [Serializable]
    public class HealthData
    {
        [field: SerializeField]
        public GameObject GameObject { get; private set; }

        [field: SerializeField]
        public DamagableBody DamagableBody { get; private set; }
        
        [field: SerializeField, Min(0)]
        public int MaxHealth { get; private set; } = 1;
    }
}