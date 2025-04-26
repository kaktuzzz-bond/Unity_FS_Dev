using System;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class HealthSettings
    {
        [SerializeField, Min(0)]
        private int maxHealth = 10;

        public int MaxHealth => maxHealth;
    }
}