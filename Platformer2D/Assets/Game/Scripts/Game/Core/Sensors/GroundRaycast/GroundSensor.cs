using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Sensors.GroundRaycast
{
    [Serializable]
    public class GroundSensor : IGroundSensor
    {
        [SerializeField]
        private Transform origin;

        [SerializeField]
        private LayerMask groundLayer;

        private const float Distance = 0.1f;


        public bool IsGrounded =>
            Physics2D.Raycast(
                origin.position, Vector2.down, Distance, groundLayer);
    }
}