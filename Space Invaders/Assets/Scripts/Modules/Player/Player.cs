using System;
using UnityEngine;

namespace Modules.Player
{
    public sealed class Player : MonoBehaviour
    {
        //public Action<Player, int> OnHealthChanged;
        public Action<Player> OnHealthEmpty;
        public event Action<Transform> OnBulletRequired;

        [SerializeField] public Transform firePoint;

        [SerializeField] private Rigidbody2D rigidbody;

        [SerializeField] public bool isPlayer;
        [SerializeField] public int health;

        [SerializeField] public float speed = 5.0f;

        private bool _isFireMode;

        public void Move(Vector2 direction)
        {
            var moveStep = direction * speed * Time.fixedDeltaTime;
            var targetPosition = rigidbody.position + moveStep;
            rigidbody.MovePosition(targetPosition);
        }

        public void Fire()
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