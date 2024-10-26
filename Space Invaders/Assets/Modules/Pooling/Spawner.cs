using System.Collections.Generic;
using UnityEngine;

namespace Modules.Pooling
{
    public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolReleasable<T>
    {
        [SerializeField] protected T prefab;
        [SerializeField] protected Transform parent;
        [SerializeField, Min(0)] protected int poolSize;

        protected ObjectPool<T> pool;

        protected virtual void Awake()
        {
            pool = new ObjectPool<T>(prefab, parent, poolSize);
        }

        protected T Spawn()
        {
            var item = pool.Spawn();

            item.transform.position = parent.position;

            return item;
        }

        protected T Spawn(Vector2 position)
        {
            var item = pool.Spawn();

            item.transform.position = position;

            return item;
        }

        protected T Spawn(Vector2 position, Quaternion rotation)
        {
            var item = pool.Spawn();

            item.transform.SetPositionAndRotation(position, rotation);

            return item;
        }
    }
}