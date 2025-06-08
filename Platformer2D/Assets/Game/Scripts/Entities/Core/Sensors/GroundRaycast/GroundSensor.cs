using System;
using UnityEngine;

namespace Game.Entities
{
    [Serializable]
    public class GroundSensor : IGroundSensor
    {
        [SerializeField]
        private Transform origin;

        [SerializeField]
        private LayerMask groundLayer;

        private const float Distance = 0.1f;

        //[ShowInInspector, ReadOnly, HideInEditorMode]
        public bool IsGrounded =>
            Physics2D.Raycast(
                origin.position, Vector2.down, Distance, groundLayer);
    }
}