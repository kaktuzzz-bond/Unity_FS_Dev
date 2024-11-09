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
            inputAdapter.OnFirePressed += playerService.Attack;
            inputAdapter.OnMove += playerService.Move;
        }


        private void OnDisable()
        {
            inputAdapter.OnFirePressed -= playerService.Attack;
            inputAdapter.OnMove -= playerService.Move;
        }
    }
}