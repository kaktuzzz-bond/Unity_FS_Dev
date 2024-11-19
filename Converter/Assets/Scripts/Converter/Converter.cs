using System;
using System.Collections.Generic;
using System.Linq;


namespace Converter
{
    public sealed class Converter<TLoad, TUnload> where TLoad : class
                                                  where TUnload : class, new()
    {
        private readonly Storage<TLoad> _loadingArea;
        private readonly Storage<TUnload> _unloadingArea;
        private readonly int _capacity;


        public Converter(int loadingAreaCapacity, int unloadingAreaCapacity, int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException($"<{capacity}> :: Converter capacity should be non-negative");

            _capacity = capacity;
            _loadingArea = new Storage<TLoad>(loadingAreaCapacity);
            _unloadingArea = new Storage<TUnload>(unloadingAreaCapacity);
        }


        public bool IsActive { get; private set; }
        public float Efficiency { get; private set; }
        public float Duration { get; private set; }


        public bool SetDuration(float duration)
        {
            if (duration < 0)
                throw new ArgumentOutOfRangeException($"<{duration}> :: Duration should be non-negative");

            Duration = duration;

            return true;
        }


        public bool SetEfficiency(float efficiencyValue)
        {
            if (efficiencyValue is < 0 or > 1)
                throw new ArgumentOutOfRangeException(nameof(SetEfficiency), efficiencyValue,
                                                      "Value must be in 0..1 range.");

            Efficiency = efficiencyValue;

            return true;
        }


        public void Start()
        {
            IsActive = true;
        }


        public void Stop()
        {
            IsActive = false;
        }


        public void AddResources(IEnumerable<TLoad> items)
        {
            _loadingArea.AddResources(items);
        }


        public IEnumerable<TUnload> Unload()
        {
            return _unloadingArea.GetResources(_capacity);
        }


        public void Convert()
        {
            while (IsActive)
            {
                var resources = _loadingArea.GetResources(_capacity).ToArray();
                var productCount = (int)(resources.Length * Efficiency);
                var product = Produce(productCount);
                _unloadingArea.AddResources(product);
            }
        }


        private IEnumerable<TUnload> Produce(int count)
        {
            var product = new TUnload[count];

            for (var i = 0; i < count; i++)
            {
                product[i] = new TUnload();
            }

            return product;
        }
    }
}