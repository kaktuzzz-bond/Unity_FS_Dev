using System;
using Gameplay.Spaceships;
using Gameplay.Spaceships.Weapon;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerService : MonoBehaviour
    {
        public event Action OnPlayerDeath;
        [SerializeField] private Spaceship prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private BulletSpawner bulletSpawner;

        public Spaceship PlayerSpaceship => _player;

        private Spaceship _player;

        private void Awake()
        {
            _player = Instantiate(prefab, parent);
            _player.SetWeapon(bulletSpawner);
        }

        private void OnEnable()
        {
            _player.OnDeath += OnPlayerDeathHandler;
        }

        private void OnPlayerDeathHandler(Spaceship spaceship)
        {
            OnPlayerDeath?.Invoke();
        }

        private void OnDisable()
        {
            _player.OnDeath -= OnPlayerDeathHandler;
        }
    }
}