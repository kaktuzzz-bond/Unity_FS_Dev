using System;
using Game.Scripts.Components.Cooldown;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class JumpSettings
    {
        [SerializeField, Min(0)]
        private float jumpForce = 10;

        [SerializeField, Min(0)]
        private float jumpCooldown = 2;

        public float JumpForce => jumpForce;
        public float JumpCooldown => jumpCooldown;

        public CooldownTimer CreateTimer => new(jumpCooldown);
    }
}