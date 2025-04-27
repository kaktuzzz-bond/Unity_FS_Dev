using System;
using UnityEngine;

namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class PushSettings
    {
        [SerializeField, Min(0)]
        private float pushCooldown = 2;

        [SerializeField, Min(0)]
        private float tossCooldown = 2;

        public float PushCooldown => pushCooldown;
        public float TossCooldown => tossCooldown;
    }
}