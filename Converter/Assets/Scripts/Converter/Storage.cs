using System;
using System.Collections.Generic;
using UnityEngine;

namespace Converter
{
    public class Storage<T> where T : class
    {
        public event Action OnFull;

        private readonly int _capacity;

        private readonly Queue<T> _storage;


        public Storage(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(T), capacity,
                                                      "The convertorCapacity cannot be negative.");

            _capacity = capacity;
            _storage = new Queue<T>(_capacity);
        }


        public int Count =>
            _storage.Count;


        public IEnumerable<T> Get(int count)
        {
            count = Mathf.Clamp(count, 0, Count);

            var items = new T[count];

            for (var i = 0; i < count; i++)
            {
                items[i] = _storage.Dequeue();
            }

            return items;
        }


        public bool GetSingle(out T item)
        {
            item = null;

            return _storage.Count != 0 && _storage.TryDequeue(out item);
        }


        public int Add(params T[] items)
        {
            var count = 0;

            if (items == null || items.Length == 0) return 0;

            if (_capacity - _storage.Count < items.Length) return 0;

            foreach (var item in items)
            {
                if (!AddItem(item)) continue;

                count++;
            }

            return count;
        }


        public bool Contains(T item) =>
            _storage.Contains(item);


        public void Clear() =>
            _storage.Clear();


        public IEnumerable<T> GetAll() =>
            new List<T>(_storage);


        private bool AddItem(T item)
        {
            if (item == null || Contains(item))
                return false;

            _storage.Enqueue(item);

            if (Count > _capacity)
                throw new OverflowException($":: OVERFLOW :: Capacity was [{_capacity}] but the storage is [{Count}].");

            if (Count == _capacity)
                OnFull?.Invoke();

            return true;
        }
    }
}