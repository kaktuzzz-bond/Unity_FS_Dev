using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Sensors.EntityRaycast
{
    [Serializable]
    public class EntitySensorData
    {
        [field: SerializeField]
        public Transform Origin { get; private set; }

        [field: SerializeField, Min(0)]
        public float RaycastDistance { get; private set; } = 1;
        
        [field: SerializeField]
        public LayerMask LayerMask { get; private set; }
    }
}