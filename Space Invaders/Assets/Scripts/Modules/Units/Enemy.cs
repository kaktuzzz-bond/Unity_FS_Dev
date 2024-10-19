using UnityEngine;

namespace Modules.Enemies
{
    public sealed class Enemy : UnitBase
    {
        public delegate void FireHandler(Vector2 position, Vector2 direction);
        
        public event FireHandler OnFire;
        
        [SerializeField]
        private float countdown;

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

        public override void Move(Vector2 direction)
        {
            Vector2 vector = this._destination - (Vector2) this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this._isPointReached = true;
                return;
            }

            Vector2 dir = vector.normalized * Time.fixedDeltaTime;
            Vector2 nextPosition = rigidbody.position + dir * speed;
            rigidbody.MovePosition(nextPosition);
        }

        public override void Attack()
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
        
        private void FixedUpdate()
        {
            if (this._isPointReached)
            {
               Attack();
            }
            else
            {
                
                Move(Vector2.zero);
            }
        }

       
    }
}