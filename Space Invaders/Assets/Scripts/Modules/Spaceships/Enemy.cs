using System.Collections;
using UnityEngine;

namespace Modules.Spaceships
{
    public sealed class Enemy : SpaceshipBase
    {
        [SerializeField] private float attackInterval = 1f;

        private Coroutine _attackRoutine;
        private bool _isOnAttackPosition;


        public override void Move(Vector2 direction)
        {
            if (_isOnAttackPosition) return;

            if (direction.magnitude <= 0.25f)
            {
                _isOnAttackPosition = true;
                _attackRoutine = StartCoroutine(AttackRoutine());
                return;
            }

            base.Move(direction.normalized);
        }

        public override void OnDespawn()
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
            }

            base.OnDespawn();
        }

        private IEnumerator AttackRoutine()
        {
            while (_isOnAttackPosition)
            {
                yield return new WaitForSeconds(attackInterval);
                Attack();
            }
        }

        private void FixedUpdate()
        {
            if (_isOnAttackPosition) return;

            Move(destination - (Vector2)transform.position);
        }
    }
}