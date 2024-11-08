using Modules.InputSystem;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerService playerService;
        [SerializeField] private InputAdapter inputAdapter;


        private void OnEnable()
        {
            inputAdapter.OnFirePressed += playerService.PlayerSpaceship.Attack;
            inputAdapter.OnMove += playerService.PlayerSpaceship.Move;
        }


        private void OnDisable()
        {
            inputAdapter.OnFirePressed -= playerService.PlayerSpaceship.Attack;
            inputAdapter.OnMove -= playerService.PlayerSpaceship.Move;
        }
    }
}