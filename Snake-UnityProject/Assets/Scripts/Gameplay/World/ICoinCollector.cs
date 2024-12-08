using System;
using UnityEngine;

namespace Gameplay.World
{
    public interface ICoinCollector
    {
        event Action OnGameWon;

        bool CollectCoins(Vector2Int position, out int bones);

        void DropNewCoins(int count = 1);
    }
}