using System;
using System.Collections.Generic;


namespace Converter
{
    public sealed class Storage<T> where T : class
    {
        private readonly int _capacity;
        private readonly Queue<T> _items = new();


        public Storage(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity,
                                                      "Value must be greater than or equal to zero.");

            _capacity = capacity;
        }


        public int Count => _items.Count;


        public void AddResources(IEnumerable<T> resources)
        {
            if (resources == null)
                throw new ArgumentNullException(nameof(resources), "Resources cannot be null.");

            foreach (var item in resources)
            {
                if (!CanAdd(item) || Count >= _capacity)
                    continue;

                _items.Enqueue(item);
            }
        }


        public IEnumerable<T> GetResources(int requestedAmount)
        {
            var items = new List<T>();

            if (requestedAmount <= 0) return items;

            for (var i = 0; i < requestedAmount; i++)
            {
                if (_items.TryDequeue(out T item))
                    items.Add(item);
            }

            return items;
        }


        public bool Contains(T item) =>
            _items.Contains(item);


        private bool CanAdd(T item) =>
            item != null &&
            !Contains(item);
    }
}