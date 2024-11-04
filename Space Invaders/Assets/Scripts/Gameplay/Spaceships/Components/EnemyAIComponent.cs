using System.Collections;
using UnityEngine;

namespace Gameplay.Spaceships.Components
{
    public class EnemyAIComponent : MonoBehaviour
    {
        [SerializeField] private Spaceship spaceship;
        [SerializeField] private float attackInterval = 1f;

        private Vector2 _attackPosition;
        private bool _isOnAttackPosition;

        private void OnEnable()
        {
            //spaceship.OnDied += Stop;
        }

        private void Stop()
        {
            _isOnAttackPosition = false;
        }

        private void Move(Vector2 direction)
        {
            if (_isOnAttackPosition) return;

            if (direction.magnitude <= 0.25f)
            {
                _isOnAttackPosition = true;
                StartCoroutine(AttackRoutine());
                return;
            }

            spaceship.Move(direction.normalized);
        }

        public void SetAttackPosition(Vector2 position) =>
            _attackPosition = position;

        private IEnumerator AttackRoutine()
        {
            while (_isOnAttackPosition)
            {
                yield return new WaitForSeconds(attackInterval);
                spaceship.Attack();
            }
        }


        private void FixedUpdate()
        {
            if (_isOnAttackPosition) return;

            Move(_attackPosition - (Vector2)transform.position);
        }
    }
}