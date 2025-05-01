using System;
using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    [Serializable]
    public class PusherData
    {
        [field: SerializeField]
        public float Force { get; private set; } = 10;
    }
}