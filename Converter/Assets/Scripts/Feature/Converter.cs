using System;
using UnityEngine;

namespace Feature
{
    public class Converter<TResource, TProduct>
    {
        public bool IsLocked { get; private set; }

        public int ResourceCount => _resourceStorage.Count;
        public int ProductCount => _productStorage.Count;

        public Type ResourceType = typeof(TResource);
        public Type ProductType = typeof(TProduct);

        private readonly Storage _resourceStorage;
        private readonly Storage _productStorage;

        private readonly int _resourceGrabValue;
        private readonly int _productPerLoadValue;

        private readonly float _produceTime;

        private float _currentTime;


        public Converter(int resourceStorageCapacity = 1,
                         int productStorageCapacity = 1,
                         int resourceGrabValue = 1,
                         int productPerLoadValue = 1,
                         float produceTime = 1f)
        {
            _resourceStorage = new Storage(resourceStorageCapacity);
            _productStorage = new Storage(productStorageCapacity);

            _resourceGrabValue = Mathf.Clamp(resourceGrabValue, 0, int.MaxValue);
            _productPerLoadValue = Mathf.Clamp(productPerLoadValue, 0, int.MaxValue);
            _produceTime = Mathf.Clamp(produceTime, 0, float.MaxValue);
        }


        public bool AddResources(int amount, out int giveBack)
        {
            return _resourceStorage.Add(amount, out giveBack);
        }


        public void Update(float deltaTime)
        {
            if (!_resourceStorage.HasRequiredAmount(_resourceGrabValue))
                return;

            if (!IsLocked)
                GrabFromResources();

            if (!IsTimerExpired(deltaTime))
                return;

            ProduceProduct();
        }


        private void GrabFromResources()
        {
            if (!_resourceStorage.Extract(_resourceGrabValue, out var resources))
            {
                return;
            }

            IsLocked = true;
            ResetTimer();
        }


        private void ProduceProduct()
        {
            if (!_productStorage.TryAdd(_productPerLoadValue))
                return;

            if (!_productStorage.Add(_productPerLoadValue, out _))
            {
                Debug.LogError($"Failed to add product after the successful check-up to {_productStorage}");

                return;
            }

            IsLocked = false;
        }


        private bool IsTimerExpired(float step) =>
            (_currentTime -= step) <= 0f;


        private void ResetTimer() =>
            _currentTime = _produceTime;


        public class Storage
        {
            public int Count { get; private set; }

            private readonly int _capacity;

            private int _diff;


            public Storage(int capacity)
            {
                _capacity = Mathf.Clamp(capacity, 0, int.MaxValue);
            }


            public bool TryAdd(int amount)
            {
                if (amount <= 0)
                    return false;

                return CalculateDifference(amount) >= 0;
            }


            public bool Add(int amount, out int giveBack)
            {
                giveBack = 0;

                if (amount <= 0)
                    return false;

                _diff = CalculateDifference(amount);

                if (_diff < 0)
                {
                    Count = _capacity;

                    giveBack = -_diff;

                    return false;
                }

                Count += amount;

                return true;
            }


            public bool HasRequiredAmount(int requestedAmount) =>
                requestedAmount > 0 && Count >= requestedAmount;


            public bool Extract(int requestedAmount, out int result)
            {
                result = 0;

                if (requestedAmount > _capacity || requestedAmount <= 0)
                    return false;

                if (requestedAmount > Count)
                {
                    result = Count;

                    return false;
                }

                Count -= requestedAmount;
                result = requestedAmount;

                return true;
            }


            private int CalculateDifference(int amount) =>
                _capacity - Count - amount;
        }
    }
}