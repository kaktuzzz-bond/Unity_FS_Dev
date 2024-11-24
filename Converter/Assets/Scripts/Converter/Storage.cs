using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Converter
{
    public class Storage<T> : IEnumerable<T> where T : class
    {
        public int Capacity { get; }

        private readonly Queue<T> _storage;


        public Storage(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(T), capacity,
                                                      "The convertorCapacity cannot be negative.");

            Capacity = capacity;
            _storage = new Queue<T>(Capacity);
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


        public bool Add(out List<T> overloads, params T[] items)
        {
            overloads = new List<T>();

            if (items == null || items.Length == 0) return false;

            foreach (var item in items)
            {
                if (item == null || Contains(item) || AddItem(item))
                    continue;

                overloads.Add(item);
            }

            return overloads.Count == 0;
        }


        public bool Contains(T item) =>
            _storage.Contains(item);


        public void Clear() =>
            _storage.Clear();


        public IEnumerable<T> GetAll() =>
            new List<T>(_storage);


        public bool AddItem(T item)
        {
            if (item == null || Count == Capacity)
                return false;

            _storage.Enqueue(item);

     

            return true;
        }
        


        public IEnumerator<T> GetEnumerator()
        {
            return _storage.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}