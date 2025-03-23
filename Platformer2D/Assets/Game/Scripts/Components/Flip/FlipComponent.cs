using UnityEngine;

namespace Game.Scripts.Components.Flip
{
    public class FlipComponent : IFlipComponent
    {
        private readonly Transform _target;

        private Vector3 _localScale = Vector3.one;
        
        public FlipComponent(Transform target)
        {
            _target = target;
        }

        public void LookTowards(Vector3 direction)
        {
            if (direction.x == 0) return;

            _localScale.x = direction.x;
            _target.localScale = _localScale;
        }
    }
}