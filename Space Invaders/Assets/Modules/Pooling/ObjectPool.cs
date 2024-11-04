using System.Collections.Generic;
using UnityEngine;

namespace Modules.Pooling
{
    public abstract class ObjectPool<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private T prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int poolCapacity;

        private readonly Queue<T> _pool = new();
        
        private void Awake()
        {
            FillPool(poolCapacity);
        }

        private void FillPool(int capacity)
        {
            for (var i = 0; i < capacity; i++)
            {
                var item = GetNewInstance();
                Return(item);
            }
        }

        public T Rent()
        {
            if (!_pool.TryDequeue(out var item))
            {
                item = GetNewInstance();
                OnCreate(item);
            }

            item.gameObject.SetActive(true);
            OnRent(item);

            return item;
        }

        public T Rent(Vector2 position, Quaternion rotation)
        {
            if (!_pool.TryDequeue(out var item))
            {
                item = GetNewInstance();
                OnCreate(item);
            }

            item.transform.SetPositionAndRotation(position, rotation);
            item.gameObject.SetActive(true);
            OnRent(item);

            return item;
        }

        public void Return(T item)
        {
            if (_pool.Contains(item)) return;

            OnReturn(item);

            item.gameObject.SetActive(false);
            _pool.Enqueue(item);
        }


        protected virtual void OnCreate(T item)
        {
        }

        protected virtual void OnRent(T item)
        {
        }

        protected virtual void OnReturn(T item)
        {
        }

        private T GetNewInstance() =>
            Instantiate(prefab, parent);
    }
}