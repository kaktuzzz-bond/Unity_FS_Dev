using UnityEngine;

namespace Game.Scripts.Components.Flip
{
    public class FlipUseCase: IFlippable
    {
        private readonly Transform _body;
        private Vector3 _direction = Vector3.one;

        public FlipUseCase(Transform body)
        {
            _body = body;
        }

        public Vector3 GetDirection => _direction;

       
        public void LookTowards(Vector3 direction)
        {
            if (direction.x == 0) return;
            _direction.x = direction.x < 0 ? -1 : 1;
            _body.localScale = _direction;
        }

        public void LookTowardsX(float direction)
        {
            if (direction == 0) return;
            _direction.x = direction < 0 ? -1 : 1;
            _body.localScale = _direction;
        }
    }
}