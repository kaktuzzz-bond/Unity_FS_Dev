using System;
using Gameplay.Spaceships;
using Gameplay.Weapon;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerService : MonoBehaviour
    {
        public event Action OnPlayerDeath;
        public ISpaceship PlayerSpaceship { get; private set; }

        [SerializeField] private SpaceshipConfig spaceshipConfig;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private PlayerCreator playerCreator;

        public void AddPlayer()
        {
            PlayerSpaceship = playerCreator.Create(spaceshipConfig, bulletSpawner);
            PlayerSpaceship.OnActivate();
            PlayerSpaceship.OnDeath += OnPlayerDeathHandler;
        }


        public void Move(Vector2 direction)
        {
            PlayerSpaceship.Move(direction);
        }

        public void Attack()
        {
            PlayerSpaceship.Attack(Vector2.up);
        }

        private void OnPlayerDeathHandler(ISpaceship spaceship)
        {
            OnPlayerDeath?.Invoke();
            PlayerSpaceship.OnDeactivate();
            PlayerSpaceship.OnDeath -= OnPlayerDeathHandler;
        }
    }
}