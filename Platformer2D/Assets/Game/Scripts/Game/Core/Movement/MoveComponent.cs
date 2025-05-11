using System;
using Modules.Conditions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Game.Core.Movement
{
    [Serializable]
    public class MoveComponent : IMoveComponent
    {
        [SerializeField]
        private Rigidbody2D rigidbody;

        [SerializeField]
        private Transform body;

        [SerializeField]
        private float speed;

        [SerializeField]
        private bool isFlippable;

        private Vector3 _scale = Vector3.one;


        private readonly CompositeCondition _condition = new();

        [ShowInInspector, HideInEditorMode]
        public bool IsValid => _condition.IsValid;


        public void Move(Vector2 direction)
        {
            if (!_condition.IsValid)
            {
                Debug.Log("Cannot MOVE because of conditions");

                return;
            }

            var x = Mathf.Approximately(direction.x, 0) ? rigidbody.velocity.x : direction.x * speed;
            var y = Mathf.Approximately(direction.y, 0) ? rigidbody.velocity.y : direction.y * speed;

            rigidbody.velocity = new Vector2(x, y);

            if (!isFlippable) return;

            LookTowardsX(direction.x);
        }

        private void LookTowardsX(float direction)
        {
            if (direction == 0) return;
            _scale.x = direction < 0 ? -1 : 1;

            body.localScale = _scale;
        }


        public void AddCondition(Func<bool> condition) => _condition.AddCondition(condition);

        public void RemoveCondition(Func<bool> condition) => _condition.RemoveCondition(condition);
    }
}