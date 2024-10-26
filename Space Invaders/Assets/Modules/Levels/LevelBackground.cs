using System;
using UnityEngine;

namespace Modules.Levels
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField] private float height;
        [SerializeField] private float movingSpeedY;

        private float movementY;

        private bool _isMoving;

        public void StartMoving()
        {
            _isMoving = true;
        }


        private void Update()
        {
            if (!_isMoving) return;

            transform.Translate(Vector3.down * movingSpeedY * Time.deltaTime);

            if (transform.position.y <= -height)
            {
                transform.position = new Vector3(transform.position.x, height, transform.position.z);
            }
        }
    }
}