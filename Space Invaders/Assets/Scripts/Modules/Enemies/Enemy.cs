using UnityEngine;

namespace Modules.Enemies
{
    public sealed class Enemy : MonoBehaviour
    {
        public delegate void FireHandler(Vector2 position, Vector2 direction);
        
        public event FireHandler OnFire;

        [SerializeField]
        public bool isPlayer;
        
        [SerializeField]
        public Transform firePoint;
        
        [SerializeField]
        public int health;

        [SerializeField]
        public Rigidbody2D _rigidbody;

        [SerializeField]
        public float speed = 5.0f;

        [SerializeField]
        private float countdown;

        // [NonSerialized]
        // public Player target;

        private Transform _target;
        private Vector2 _destination;
        private float _currentTime;
        private bool _isPointReached;

        public void Reset()
        {
            this._currentTime = this.countdown;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
        public void SetDestination(Vector2 endPoint)
        {
            this._destination = endPoint;
            this._isPointReached = false;
        }

        private void FixedUpdate()
        {
            if (this._isPointReached)
            {
                //Attack:
                //TODO: target = Player
                // if (this.target.health <= 0)
                //     return;

                this._currentTime -= Time.fixedDeltaTime;
                if (this._currentTime <= 0)
                {
                    Vector2 startPosition = this.firePoint.position;
                    Vector2 vector = (Vector2) _target.transform.position - startPosition;
                    Vector2 direction = vector.normalized;
                    this.OnFire?.Invoke(startPosition, direction);
                    
                    this._currentTime += this.countdown;
                }
            }
            else
            {
                //Move:
                Vector2 vector = this._destination - (Vector2) this.transform.position;
                if (vector.magnitude <= 0.25f)
                {
                    this._isPointReached = true;
                    return;
                }

                Vector2 direction = vector.normalized * Time.fixedDeltaTime;
                Vector2 nextPosition = _rigidbody.position + direction * speed;
                _rigidbody.MovePosition(nextPosition);
            }
        }
    }
}