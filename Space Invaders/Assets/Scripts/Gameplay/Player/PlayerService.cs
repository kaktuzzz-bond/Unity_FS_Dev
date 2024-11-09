using System;
using Gameplay.Spaceships;
using Gameplay.Weapon;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerService : MonoBehaviour
    {
        public event Action OnPlayerDeath;
        public Spaceship PlayerSpaceship { get; private set; }

        [SerializeField] private SpaceshipConfig spaceshipConfig;
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private PlayerCreator playerCreator;

        private void Awake()
        {
            PlayerSpaceship = playerCreator.Create(spaceshipConfig, bulletSpawner);
            PlayerSpaceship.OnActivate();
        }

        private void OnEnable()
        {
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

        private void OnPlayerDeathHandler(Spaceship spaceship)
        {
            OnPlayerDeath?.Invoke();
            PlayerSpaceship.OnDeactivate();
        }

        private void OnDisable()
        {
            PlayerSpaceship.OnDeath -= OnPlayerDeathHandler;
        }
    }
}