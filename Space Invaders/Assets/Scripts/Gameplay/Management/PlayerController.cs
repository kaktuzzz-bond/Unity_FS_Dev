using Modules.PlayerInput;
using UnityEngine;

namespace Gameplay.Management
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputAdapter inputAdapter;
        [SerializeField] private PlayerService playerService;

        private void OnEnable()
        {
            inputAdapter.OnFirePressed += playerService.Attack;
            inputAdapter.OnLeftPressed += playerService.MoveLeft;
            inputAdapter.OnRightPressed += playerService.MoveRight;
        }


        private void OnDisable()
        {
            inputAdapter.OnFirePressed -= playerService.Attack;
            inputAdapter.OnLeftPressed -= playerService.MoveLeft;
            inputAdapter.OnRightPressed -= playerService.MoveRight;
        }
    }
}