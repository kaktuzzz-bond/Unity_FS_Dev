using UnityEngine;

namespace Gameplay.Player
{
    public class WorldPoint : MonoBehaviour
    {
        public Transform Value { get; private set; }


        private void Awake() =>
            Value = transform;
    }
}