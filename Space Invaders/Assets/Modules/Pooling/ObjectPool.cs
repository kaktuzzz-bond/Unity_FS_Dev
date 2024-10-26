using System.Collections.Generic;
using UnityEngine;

namespace Modules.Pooling
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly int _capacity;

        private readonly Queue<T> _pool = new();

        public ObjectPool(T prefab, Transform parent, int capacity = 4)
        {
            _prefab = prefab;
            _parent = parent;
            _capacity = capacity;

            for (var i = 0; i < capacity; i++)
            {
                var item = GetNewInstance();
               Despawn(item);
            }
        }

        public T Spawn() =>
            _pool.TryPeek(out T item)
                ? _pool.Dequeue()
                : GetNewInstance();
        
        public void Despawn(T item)
        {
            item.gameObject.SetActive(false);
            _pool.Enqueue(item);
        }

        private T GetNewInstance() =>
            Object.Instantiate(_prefab, _parent);
    }
}