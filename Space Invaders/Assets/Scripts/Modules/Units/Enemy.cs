using Modules.Enemies;
using UnityEngine;

namespace Modules.Units
{
    public sealed class Enemy : SpaceshipBase
    {
        [SerializeField]
        private float countdown;
        
        private float _currentTime;
        private bool _isPointReached;

        public void Reset()
        {
            _currentTime = countdown;
        }
        
        public override void Move(Vector2 direction)
        {
            var vector = destination - (Vector2) transform.position;
            
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

            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Vector2 startPosition = firePoint.position;
                var velocity = ((Vector2) target.transform.position - startPosition).normalized;
                
                bulletFactory.SpawnEnemyBullet(startPosition, velocity);
                    
                _currentTime += countdown;
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