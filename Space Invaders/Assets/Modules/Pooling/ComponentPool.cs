using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Pooling
{
    public sealed class ComponentPool<T> where T : Component
    {
        public int Count => _pool.Count;

        private readonly Func<T> _creatCallback;

        private readonly Queue<T> _pool = new();


        public ComponentPool(Func<T> creatCallback, int capacity = 1)
        {
            _creatCallback = creatCallback;

            FillPool(capacity);
        }

        public T Rent()
        {
            if (!_pool.TryDequeue(out var item))
            {
                item = GetNewInstance();
            }

            item.gameObject.SetActive(true);

            return item;
        }

        public bool Return(T item)
        {
            if (_pool.Contains(item)) return false;

            item.gameObject.SetActive(false);
            _pool.Enqueue(item);

            return true;
        }


        private void FillPool(int capacity)
        {
            if (capacity <= 0) return;

            for (var i = 0; i < capacity; i++)
            {
                var item = GetNewInstance();
                Return(item);
            }
        }


        private T GetNewInstance()
        {
            return _creatCallback?.Invoke();
        }
    }
}