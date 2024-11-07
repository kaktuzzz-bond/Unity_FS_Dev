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
            capacity = Mathf.Clamp(capacity, 0, int.MaxValue);

            _creatCallback = creatCallback ?? throw new ArgumentNullException(nameof(creatCallback));

            FillPool(capacity);
        }

        public T Rent()
        {
            var item = GetItemFromPool();

            item.gameObject.SetActive(true);

            return item;
        }

        public bool Return(T item)
        {
            if (item == null)
                throw new ArgumentNullException($"The item type of {typeof(T).Name} expected but was null. )");
            
            if (_pool.Contains(item)) return false;

            item.gameObject.SetActive(false);
            _pool.Enqueue(item);

            return true;
        }


        private T GetItemFromPool()
        {
            return _pool.TryDequeue(out var item)
                ? item
                : _creatCallback?.Invoke();
        }

        private void FillPool(int capacity)
        {
            if (capacity <= 0) return;

            for (var i = 0; i < capacity; i++)
            {
                var item = _creatCallback?.Invoke();
                Return(item);
            }
        }
    }
}