using UnityEngine;

namespace Modules.Pooling.Scripts
{
    public interface IComponentPool<T> where T : Component
    {
        int Count { get; }
        T Rent();
        bool Return(T item);
        void OnCreate(T item);
        void OnRent(T item);
        void OnReturn(T item);
    }
}