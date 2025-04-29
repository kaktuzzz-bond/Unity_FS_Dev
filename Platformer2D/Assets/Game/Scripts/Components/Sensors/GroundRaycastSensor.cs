using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Sensors
{
    public class GroundRaycastSensor : IGroundRaycastSensor
    {
        private readonly Transform _origin;
        private readonly LayerMask _groundLayer;

        private const float Distance = 0.1f;

        public GroundRaycastSensor(Transform origin, LayerMask groundLayer)
        {
            _origin = origin;
            _groundLayer = groundLayer;
        }

        public bool IsGrounded =>
            Physics2D.Raycast(
                _origin.position, Vector2.down, Distance, _groundLayer);
    }
}