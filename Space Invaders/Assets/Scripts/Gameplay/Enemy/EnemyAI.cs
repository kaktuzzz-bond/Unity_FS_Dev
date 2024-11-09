using System.Collections.Generic;
using Gameplay.Player;
using Gameplay.Spaceships;
using Modules.Extensions;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        public int EnemyCount => _enemies.Count;
        [SerializeField] private PlayerService playerService;
        [SerializeField] private Transform[] attackPositions;

        private readonly Dictionary<Spaceship, Vector2> _enemies = new();

        public void AddEnemy(Spaceship spaceship)
        {
            var attackPosition = attackPositions.GetRandomItem().position;

            _enemies[spaceship] = attackPosition;
        }

        private void FixedUpdate()
        {
            foreach (var pair in _enemies)
            {
                var direction = pair.Value - (Vector2)pair.Key.transform.position;

                if (direction.magnitude > 0.25f)
                {
                    pair.Key.Move(direction.normalized);
                }
                else
                {
                    pair.Key.Attack(Vector2.down);
                }
               
            }
        }
    }
}