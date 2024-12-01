using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
                        fileName = "PlayerInputMap",
                        menuName = "Game/New PlayerInputMap"
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

        [field: Header("Game States")]
        [field: SerializeField]
        public KeyCode StartGame { get; private set; } = KeyCode.Space;

        [field: SerializeField]
        public KeyCode PauseGame { get; private set; } = KeyCode.P;

        [field: SerializeField]
        public KeyCode ResumeGame { get; private set; } = KeyCode.R;
        
        [field: SerializeField]
        public KeyCode FinishGame { get; private set; } = KeyCode.Escape;
    }
}