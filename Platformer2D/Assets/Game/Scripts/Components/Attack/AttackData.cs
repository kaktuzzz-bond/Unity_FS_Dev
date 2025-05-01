using System;
using UnityEngine;

namespace Game.Scripts.Components.Attack
{
    [Serializable]
    public class AttackData
    {
        [field: SerializeField, Min(0)]
        public int Damage { get; private set; } = 1;
    }
}