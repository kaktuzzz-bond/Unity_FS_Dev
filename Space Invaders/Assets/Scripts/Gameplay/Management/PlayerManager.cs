using Gameplay.Bullets;
using Gameplay.Spaceships;
using Modules.PlayerInput;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Management
{
    public class PlayerManager : MonoBehaviour
    {
        public Spaceship Player { get; private set; }

        [SerializeField] private SpaceshipSpawner spaceshipSpawner;
      
        [SerializeField] private InputAdapter inputAdapter;


        private void Start()
        {
            Player ??= spaceshipSpawner.Spawn();
        }

        private void OnEnable()
        {
            inputAdapter.OnFirePressed += OnFirePressedHandler;
            inputAdapter.OnLeftPressed += OnLeftPressedHandler;
            inputAdapter.OnRightPressed += OnRightPressedHandler;
        }

        private void OnDisable()
        {
            inputAdapter.OnFirePressed -= OnFirePressedHandler;
            inputAdapter.OnLeftPressed -= OnLeftPressedHandler;
            inputAdapter.OnRightPressed -= OnRightPressedHandler;
        }


        private void OnFirePressedHandler() =>
            Player.Attack();

        private void OnLeftPressedHandler() =>
            Player.Move(Vector2.left);

        private void OnRightPressedHandler() =>
            Player.Move(Vector2.right);
    }
}