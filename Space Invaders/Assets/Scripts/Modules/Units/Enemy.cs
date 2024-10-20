using System;
using Modules.Enemies;
using UnityEngine;

namespace Modules.Units
{
    public sealed class Enemy : UnitBase
    {
        //public delegate void FireHandler(Vector2 position, Vector2 direction);
        
        public event Action<Vector2,Vector2> OnFire;
        
        [SerializeField]
        private float countdown;

        private Transform _target;
        private Vector2 _destination;
        private float _currentTime;
        private bool _isPointReached;

        public void Reset()
        {
            _currentTime = countdown;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }
        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isPointReached = false;
        }

        public override void Move(Vector2 direction)
        {
            var vector = _destination - (Vector2) transform.position;
            
            if (vector.magnitude <= 0.25f)
            {
               _isPointReached = true;
                return;
            }

            base.Move(vector.normalized);
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