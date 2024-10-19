using System;
using Modules.Enemies;
using UnityEngine;

namespace Modules.Player
{
    public sealed class Player : UnitBase
    {
        //public Action<Player, int> OnHealthChanged;
        public Action<Player> OnHealthEmpty;
        public event Action<Transform> OnBulletRequired;

        private bool _isFireMode;

        public override void Move(Vector2 direction)
        {
            var moveStep = direction * speed * Time.fixedDeltaTime;
            var targetPosition = rigidbody.position + moveStep;
            rigidbody.MovePosition(targetPosition);
        }
        public override void Attack()
        {
            _isFireMode = true;
        }

        private void FixedUpdate()
        {
            if (!_isFireMode) return;

            OnBulletRequired?.Invoke(firePoint);

            _isFireMode = false;
        }
    }
}