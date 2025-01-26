using UnityEngine;

namespace Game.Scripts.Components
{
    public class GroundRaycastComponent : IGroundRaycastComponent
    {
        private readonly Transform _target;
        private readonly LayerMask _groundLayer;

        private const float Distance = 0.1f;

        public GroundRaycastComponent(Transform target, LayerMask groundLayer)
        {
            _target = target;
            _groundLayer = groundLayer;
        }


        public bool IsGrounded =>
            Physics2D.Raycast(
                _target.position, Vector2.down, Distance, _groundLayer);
    }
}