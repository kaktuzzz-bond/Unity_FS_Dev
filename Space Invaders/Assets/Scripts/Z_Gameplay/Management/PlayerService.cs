using UnityEngine;
using Z_Gameplay.Spaceships;

namespace Z_Gameplay.Management
{
    public class PlayerService : MonoBehaviour
    {
        public Spaceship Player { get; private set; }

        [SerializeField] private SpaceshipSpawner enemySpaceshipSpawner;

        public void SpawnPlayer()
        {
            //Player ??= enemySpaceshipSpawner.Rent();
        }

        public void Attack() =>
            Player.Attack();

        public void MoveRight() =>
            Player.Move(Vector2.right);

        public void MoveLeft() =>
            Player.Move(Vector2.left);
    }
}