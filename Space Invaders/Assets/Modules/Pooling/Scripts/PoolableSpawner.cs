using System;
using UnityEngine;

namespace Modules.Pooling.Scripts
{
    public abstract class PoolableSpawner<T> : MonoBehaviour where T : Component
    {
        public int Count => _pool.Count;
        
        [SerializeField] private T prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int poolSize;

        private ComponentPool<T> _pool;

        private void Awake()
        {
            if (prefab == null)
                throw new ArgumentNullException(nameof(prefab));

            _pool = new ComponentPool<T>(CreateInstance, poolSize);
        }

        public T Rent()
        {
            var item = _pool.Rent();
            OnRent(item);
            return item;
        }

        public bool Return(T item)
        {
            var isSuccess = _pool.Return(item);

            if (isSuccess)
                OnReturn(item);

            return isSuccess;
        }


        private T CreateInstance()
        {
            var item = Instantiate(prefab, parent.position, Quaternion.identity, parent);

            OnCreate(item);

            return item;
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
    }
}