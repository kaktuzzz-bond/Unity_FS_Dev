using UnityEngine;

namespace Modules.Pooling.Scripts
{
    public abstract class PoolSpawner<T> : MonoBehaviour, IComponentPool<T> where T : Component
    {
        [SerializeField] T prefab;
        [SerializeField] Transform parent;
        [SerializeField] int poolSize = 10;

        private IComponentPool<T> _objectPool;

        public int Count => _objectPool.Count;

        private void Awake() =>
            _objectPool = new ComponentPool<T>(prefab, parent, poolSize);


        public T Rent() =>
            _objectPool.Rent();

        public bool Return(T item) =>
            _objectPool.Return(item);

        public virtual void OnCreate(T item)
        {
        }


        public virtual void OnRent(T item)
        {
        }

        public virtual void OnReturn(T item)
        {
        }
    }
}