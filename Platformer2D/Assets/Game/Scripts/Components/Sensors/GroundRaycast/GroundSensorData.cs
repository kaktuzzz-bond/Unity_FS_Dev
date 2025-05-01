using System;
using UnityEngine;

namespace Game.Scripts.Components.Sensors.GroundRaycast
{
    [Serializable]
    public class GroundSensorData
    {
        [field: SerializeField]
        public Transform Origin { get; private set; }
        
        [field: SerializeField]
        public LayerMask LayerMask { get; private set; }
    }
}