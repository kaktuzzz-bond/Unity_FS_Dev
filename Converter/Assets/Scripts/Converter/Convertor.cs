using System;
using System.Linq;

namespace Converter
{
    public class Convertor<TResource, TProduct> : IDisposable where TResource : class, IResource
                                                              where TProduct : class, new()
    {
        public bool IsActive { get; private set; }

        private readonly Storage<TResource> _resourceStorage;
        private readonly Storage<TProduct> _productStorage;

        private readonly Storage<TResource> _loadingSlot;
        private readonly Storage<TProduct> _unloadingSlot;

        private readonly Timer _timer;


        public Convertor(int resourceStorageCapacity,
                         int productStorageCapacity,
                         int loadAmount,
                         int unloadAmount,
                         float processingTime)
        {
            if (loadAmount < 0 || unloadAmount < 0)
                throw new
                    ArgumentOutOfRangeException($"Load amount [{loadAmount}] and unload amount [{unloadAmount}] cannot be negative.");

            _resourceStorage = new Storage<TResource>(resourceStorageCapacity);
            _productStorage = new Storage<TProduct>(productStorageCapacity);

            _loadingSlot = new Storage<TResource>(loadAmount);
            _unloadingSlot = new Storage<TProduct>(unloadAmount);

            _timer = new Timer(processingTime);

            _timer.OnTimeUp += OnTimeUp;
        }


        public void Start()
        {
            IsActive = true;
        }


        public void Stop()
        {
            IsActive = false;

            if (_loadingSlot.Count > 0)
            {
                _resourceStorage.Add(out _, _loadingSlot.ToArray());
            }
        }


        public void Update(float dt)
        {
            if (!IsActive) return;

            _timer.Tick(dt);
        }


        private void OnTimeUp()
        {
            Convert();

            Unload();

            Load();

            _timer.Reset();
        }


        private void Load()
        {
            var resources = _resourceStorage.Get(_loadingSlot.Capacity);

            if (!_loadingSlot.Add(out var overloads, resources.ToArray()))
            {
                _resourceStorage.Add(out _, overloads.ToArray());
            }
        }


        private void Unload()
        {
            if (!_productStorage.Add(out var overloads, _unloadingSlot.ToArray()))
            {
                _productStorage.Add(out _, overloads.ToArray());
            }
        }


        private void Convert()
        {
            foreach (var resource in _loadingSlot)
            {
                for (var i = 0; i < resource.ProductAmount; i++)
                {
                    _unloadingSlot.AddItem(new TProduct());
                }
            }
        }


        public void Dispose()
        {
            _timer.OnTimeUp -= OnTimeUp;
        }
    }
}