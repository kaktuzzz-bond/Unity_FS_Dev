using UnityEngine;

namespace Game.Scripts.Components.Movement.Flip
{
    public class FlipComponent : IFlippable
    {
        private readonly Transform _target;

        private Vector3 _localScale = Vector3.one;

        public Vector3 GetScale => _localScale;
        public FlipComponent(Transform target)
        {
            _target = target;
        }

        public void LookTowards(Vector3 direction)
        {
            if (direction.x == 0) return;

            _localScale.x = direction.x < 0 ? -1 : 1;
            _target.localScale = _localScale;
        }
    }
}