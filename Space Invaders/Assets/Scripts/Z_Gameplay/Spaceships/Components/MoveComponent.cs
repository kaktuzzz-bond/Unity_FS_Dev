using UnityEngine;

namespace Z_Gameplay.Spaceships.Components
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private float moveSpeed;


        public void Move(Vector2 direction)
        {
            var moveStep = direction * moveSpeed * Time.fixedDeltaTime;
            var targetPosition = rigidbody.position + moveStep;

            rigidbody.MovePosition(targetPosition);
        }
    }
}