using Modules.Coin;
using UnityEngine;
using Zenject;

namespace World
{
    public class CoinSpawner : MonoMemoryPool<Vector2Int, Transform, Coin>
    {
        protected override void Reinitialize(Vector2Int position, Transform parent, Coin coin)
        {
            coin.Generate();
            coin.Position = position;
            coin.transform.SetParent(parent);
           
        }
      
    }
}