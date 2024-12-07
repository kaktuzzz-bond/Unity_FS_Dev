using UnityEngine;

namespace Input.InputMaps
{
    [CreateAssetMenu(
                        fileName = "PlayerInputMap",
                        menuName = "Game/Input/New PlayerInputMap"
                    )]
    public sealed class PlayerInputMap : ScriptableObject
    {
        [field: Header("Movement")]
        [field: SerializeField]
        public KeyCode MoveLeft { get; private set; } = KeyCode.A;

        [field: SerializeField]
        public KeyCode MoveRight { get; private set; } = KeyCode.D;

        [field: SerializeField]
        public KeyCode MoveUp { get; private set; } = KeyCode.W;

        [field: SerializeField]
        public KeyCode MoveDown { get; private set; } = KeyCode.S;
    }
}