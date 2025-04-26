using System;
using UnityEngine;


namespace Game.Scripts.Player.Settings
{
    [Serializable]
    public class MoveSettings
    {
        [SerializeField, Min(0)]
        private float moveSpeed = 5;

        public float MoveSpeed => moveSpeed;
    }
}