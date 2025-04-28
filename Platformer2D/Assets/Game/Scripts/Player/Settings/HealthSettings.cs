using System;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class HealthSettings
    {
        [field: SerializeField, Min(0)]
        public int MaxHealth { get; private set; } = 10;
    };
}