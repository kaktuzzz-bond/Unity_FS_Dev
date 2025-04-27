using System;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class AttackSettings
    {
        [SerializeField, Min(0)]
        private int attackDamage;

        public int AttackDamage => attackDamage;
    }
}