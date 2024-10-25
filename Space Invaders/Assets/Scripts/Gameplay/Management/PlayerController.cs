using Gameplay.Factories;
using Gameplay.Spaceships;
using Modules.PlayerInput;
using UnityEngine;

namespace Gameplay.Management
{
    public class PlayerController : MonoBehaviour
    {
        public SpaceshipBase Player { get; private set; }

        private SpaceshipFactory _spaceshipFactory;
        private InputListener _inputListener;

        public void Initialize(SpaceshipFactory spaceshipFactory, InputListener inputListener)
        {
            _spaceshipFactory = spaceshipFactory;
            _inputListener = inputListener;

            _inputListener.OnFirePressed += OnFirePressedHandler;
            _inputListener.OnLeftPressed += OnLeftPressedHandler;
            _inputListener.OnRightPressed += OnRightPressedHandler;

            Player = _spaceshipFactory.SpawnPlayer();
        }

        private void OnFirePressedHandler() => 
            Player.Attack();

        private void OnLeftPressedHandler() => 
            Player.Move(Vector2.left);

        private void OnRightPressedHandler() => 
            Player.Move(Vector2.right);

        private void OnDestroy()
        {
            _inputListener.OnFirePressed -= OnFirePressedHandler;
            _inputListener.OnLeftPressed -= OnLeftPressedHandler;
            _inputListener.OnRightPressed -= OnRightPressedHandler;
        }
    }
}