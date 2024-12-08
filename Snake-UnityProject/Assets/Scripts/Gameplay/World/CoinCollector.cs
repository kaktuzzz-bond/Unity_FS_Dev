using System;
using System.Collections.Generic;
using System.Linq;
using Modules.Coin;
using Modules.Difficulty;
using Modules.Score;
using Modules.World;
using UnityEngine;

namespace Gameplay.World
{
    public class CoinCollector : ICoinCollector
    {
        public event Action OnGameWon;

        private readonly CoinSpawner _coinSpawner;
        private readonly WorldBounds _worldBounds;
        private readonly IDifficulty _difficulty;
        private readonly IScore _score;

        private readonly HashSet<Coin> _coins = new();


        public CoinCollector(CoinSpawner coinSpawner,
                             WorldBounds worldBounds,
                             IDifficulty difficulty,
                             IScore score)
        {
            _coinSpawner = coinSpawner;
            _worldBounds = worldBounds;
            _difficulty = difficulty;
            _score = score;
        }


        public bool CollectCoins(Vector2Int position, out int bones)
        {
            bones = 0;
            var eaten = _coins.FirstOrDefault(coin => position == coin.Position);

            if (eaten == null) return false;

            bones = eaten.Bones;

            _score.Add(eaten.Score);

            RemoveCoin(eaten);

            UpdateCoins();

            return true;
        }


        public void DropNewCoins(int count = 1)
        {
            if (count <= 0) return;

            for (var i = 0; i < count; i++)
            {
                var coin = SpawnNewCoin();
                _coins.Add(coin);
            }
        }


        private void UpdateCoins()
        {
            if (_coins.Count > 0) return;

            var moveNext = _difficulty.Next(out var difficulty);

            if (moveNext)
            {
                DropNewCoins(difficulty);

                return;
            }

            OnGameWon?.Invoke();
        }


        private void RemoveCoin(Coin coin)
        {
            if (coin == null) return;

            _coins.Remove(coin);
            _coinSpawner.Despawn(coin);
        }


        private Coin SpawnNewCoin()
        {
            var position = _worldBounds.GetRandomPosition();
            var parent = _worldBounds.transform;

            return _coinSpawner.Spawn(position, parent);
        }
    }
}