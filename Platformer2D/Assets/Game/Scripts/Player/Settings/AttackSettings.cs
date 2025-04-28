using System;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class AttackSettings
    {
        [field: SerializeField, Min(0)]
        public int AttackDamage { get; private set; }
    }
}