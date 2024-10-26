using System;
using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Management
{
    public class PlayerService : MonoBehaviour
    {
        public Spaceship Player { get; private set; }

        [SerializeField] private SpaceshipSpawner spaceshipSpawner;
        [SerializeField] private GameCycle gameCycle;

        public void SpawnPlayer()
        {
            Player ??= spaceshipSpawner.Create();
            Player.OnDied += OnPlayerDiedHandler;
        }

        private void OnPlayerDiedHandler(Spaceship spaceship)
        {
            gameCycle.GameOver();
        }

        private void OnDestroy()
        {
            Player.OnDied -= OnPlayerDiedHandler;
        }

        public void Attack() =>
            Player.Attack();

        public void MoveRight() =>
            Player.Move(Vector2.right);

        public void MoveLeft() =>
            Player.Move(Vector2.left);
    }
}