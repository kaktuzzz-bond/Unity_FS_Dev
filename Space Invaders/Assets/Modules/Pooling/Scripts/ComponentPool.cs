using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.Pooling.Scripts
{
    public class ComponentPool<T> : IComponentPool<T> where T : Component
    {
        public int Count => _pool.Count;

        private readonly T _prefab;
        private readonly Transform _parent;

        private readonly Queue<T> _pool = new();

        private Vector3 Position =>
            _parent == null ? Vector3.zero : _parent.position;


        public ComponentPool(T prefab, Transform parent, int capacity = 1)
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab));

            _prefab = prefab;
            _parent = parent;

            FillPool(capacity);
        }

        public T Rent()
        {
            if (!_pool.TryDequeue(out var item))
            {
                item = GetNewInstance(Position, Quaternion.identity);
            }

            item.gameObject.SetActive(true);
            OnRent(item);

            return item;
        }

        public bool Return(T item)
        {
            if (_pool.Contains(item)) return false;

            OnReturn(item);

            item.gameObject.SetActive(false);
            _pool.Enqueue(item);

            return true;
        }

        public virtual void OnCreate(T item)
        {
        }

        public virtual void OnRent(T item)
        {
        }

        public virtual void OnReturn(T item)
        {
        }

        private void FillPool(int capacity)
        {
            if (capacity <= 0) return;

            for (var i = 0; i < capacity; i++)
            {
                var item = GetNewInstance(Position, Quaternion.identity);
                Return(item);
            }
        }


        private T GetNewInstance(Vector3 position, Quaternion rotation)
        {
            var item = Object.Instantiate(_prefab, position, rotation);

            OnCreate(item);

            return item;
        }
    }
}