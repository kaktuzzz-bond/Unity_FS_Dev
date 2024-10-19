using UnityEngine;

namespace Modules.Levels
{
    public sealed class LevelBounds : MonoBehaviour
    {
        [SerializeField] private Transform leftBorder;

        [SerializeField] private Transform rightBorder;

        [SerializeField] private Transform downBorder;

        [SerializeField] private Transform topBorder;

        public bool InBounds(Vector3 position) => 
            IsInBoundsX(position.x) && IsInBoundsY(position.y);

        private bool IsInBoundsY(float y) =>
            y >= downBorder.position.y && y <= topBorder.position.y;

        private bool IsInBoundsX(float x) =>
            x >= leftBorder.position.x && x <= rightBorder.position.x;
    }
}