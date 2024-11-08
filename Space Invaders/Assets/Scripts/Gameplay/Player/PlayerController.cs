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
            inputAdapter.OnFirePressed += OnAttack;
            inputAdapter.OnMove += OnMove;
        }

        private void OnAttack()
        {
            playerService.PlayerSpaceship.Attack();
        }

        private void OnMove(Vector2 direction)
        {
            playerService.PlayerSpaceship.Move(direction);
        }


        private void OnDisable()
        {
            inputAdapter.OnFirePressed -= OnAttack;
            inputAdapter.OnMove -= OnMove;
        }
    }
}