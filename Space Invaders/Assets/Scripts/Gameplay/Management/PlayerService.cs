using Gameplay.Spaceships;
using UnityEngine;

namespace Gameplay.Management
{
    public class PlayerService : MonoBehaviour
    {
        public Spaceship Player { get; private set; }

        [SerializeField] private SpaceshipSpawner spaceshipSpawner;

        public void SpawnPlayer()
        {
            Player ??= spaceshipSpawner.Create();
        }

        public void Attack() =>
            Player.Attack();

        public void MoveRight() =>
            Player.Move(Vector2.right);

        public void MoveLeft() =>
            Player.Move(Vector2.left);
    }
}