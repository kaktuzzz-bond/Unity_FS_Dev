using Codice.Client.Commands;
using UnityEngine;
using Action = System.Action;

namespace Feature
{
    public class Converter<TResource, TProduct>
    {
        public event Action OnTimerReset;

        private readonly Storage _resourceStorage;
        private readonly Storage _productStorage;

        private readonly int _resourceGrabValue;
        private readonly int _productPerLoadValue;

        private readonly float _produceTime;

        private float _currentTime;
        private bool _isInProgress;


        public Converter(int resourceStorageCapacity = 1,
                         int productStorageCapacity = 1,
                         int resourceCapacity = 1,
                         int productCapacity = 1,
                         float produceTime = 1f)
        {
            _resourceStorage = new Storage(resourceStorageCapacity);
            //_productStorage = new Storage(productStorageCapacity);

            _resourceGrabValue = Mathf.Clamp(resourceCapacity, 0, int.MaxValue);
            _productPerLoadValue = Mathf.Clamp(productCapacity, 0, int.MaxValue);
            _produceTime = Mathf.Clamp(produceTime, 0, float.MaxValue);
        }


        public void Update(float deltaTime)
        {
            _currentTime -= deltaTime;

            if (_currentTime <= 0)
                ResetTimer();
        }


        private void ResetTimer()
        {
            _currentTime = _produceTime;
            OnTimerReset?.Invoke();
        }


        public bool AddResources(int amount, out int giveBack)
        {
            return _resourceStorage.Add(amount, out giveBack);
        }


        private class Storage
        {
            public int Count { get; private set; }

            private readonly int _capacity;

            private int _diff;


            public Storage(int capacity)
            {
                _capacity = Mathf.Clamp(capacity, 0, int.MaxValue);
            }


            public bool Add(int amount, out int giveBack)
            {
                giveBack = 0;

                if (amount <= 0)
                {
                    return false;
                }

                _diff = _capacity - Count - amount;

                if (_diff < 0)
                {
                    Count = _capacity;

                    giveBack = -_diff;

                    return false;
                }

                Count += amount;

                return true;
            }


            public bool Take(int amount, out int result)
            {
                result = 0;

                if (amount > _capacity || amount <= 0)
                {
                    return false;
                }

                if (amount > Count)
                {
                    result = Count;

                    return false;
                }

                Count -= amount;
                result = amount;

                return true;
            }
        }
    }
}