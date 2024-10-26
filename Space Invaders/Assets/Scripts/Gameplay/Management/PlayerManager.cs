using Gameplay.Spaceships;
using Modules.PlayerInput;
using UnityEngine;

namespace Gameplay.Management
{
    public class PlayerManager : MonoBehaviour
    {
        public Spaceship Player { get; private set; }

        [SerializeField] private Spaceship playerSpaceshipPrefab;
        [SerializeField] private Transform playerParent;
        [SerializeField] private int health = 5;
        [SerializeField] private float speed = 5f;

        [SerializeField] InputAdapter inputAdapter;

        private SpaceshipSpawner _spaceshipSpawner;

        private void Awake()
        {
            _spaceshipSpawner = new SpaceshipSpawner(playerSpaceshipPrefab, playerParent, health, speed,
                FactoryData.Tags.PlayerTag, FactoryData.Layers.PlayerSpaceshipLayer);

            Player = _spaceshipSpawner.Spawn(playerParent.position);
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