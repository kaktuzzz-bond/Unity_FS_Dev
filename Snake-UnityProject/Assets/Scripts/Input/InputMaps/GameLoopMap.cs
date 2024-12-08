using UnityEngine;

namespace Input.InputMaps
{
    [CreateAssetMenu(fileName = "NewGameLoopMap",
                     menuName = "Game/Input/New GameLoopMap")]
    public class GameLoopMap : ScriptableObject
    {
        [field: Header("Game States")]
        [field: SerializeField]
        public KeyCode StartGame { get; private set; } = KeyCode.Space;

        //[field: SerializeField]
        // public KeyCode PauseGame { get; private set; } = KeyCode.P;
        //
        // [field: SerializeField]
        // public KeyCode ResumeGame { get; private set; } = KeyCode.R;
        //
        // [field: SerializeField]
        // public KeyCode ExitGame { get; private set; } = KeyCode.Escape;
    }
}