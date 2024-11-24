using System;
using System.Linq;

namespace Converter
{
    public class Convertor<TResource, TProduct> : IDisposable where TResource : class, IResource
                                                              where TProduct : class, new()
    {
        public bool IsActive { get; private set; }

        public int ResourcesCount => _resourceStorage.Count;
        public int ProductsCount => _productStorage.Count;
        public int GrabbedCount => _grabber.Count;

        private readonly Storage<TResource> _resourceStorage;

        private readonly Storage<TProduct> _productStorage;

        private readonly Storage<TResource> _grabber;

        private readonly int _productPerConversion;

        private readonly Timer _timer;


        public Convertor(int resourceStorageCapacity,
                         int productStorageCapacity,
                         int converterCapacity,
                         int productPerConversion,
                         float processingTime)
        {
            if (converterCapacity < 0 || productPerConversion < 0)
                throw new
                    ArgumentOutOfRangeException($"Load amount [{converterCapacity}] and unload amount [{productPerConversion}] cannot be negative.");

            _productPerConversion = productPerConversion;

            _resourceStorage = new Storage<TResource>(resourceStorageCapacity);
            _productStorage = new Storage<TProduct>(productStorageCapacity);

            _grabber = new Storage<TResource>(converterCapacity);

            _timer = new Timer(processingTime, false);

            _timer.OnTimeUp += OnTimeUp;
        }


        public void Dispose()
        {
            _timer.OnTimeUp -= OnTimeUp;
        }


        public void Start()
        {
            LoadFromResourcesToSlot();

            IsActive = true;
        }


        public void Stop()
        {
            IsActive = false;

            ReturnResourceFromGrabber();
        }


        public void Update(float dt)
        {
            if (!IsActive) return;
           
            if (_productStorage.Count == _productStorage.Capacity) return;

            _timer.Tick(dt);
        }


        public bool AddResourcesToStorage(params TResource[] resources)
        {
            return _resourceStorage.Add(out _, resources);
        }


        private void OnTimeUp()
        {
            ConvertResourcesAndPutToProductSlot();

            LoadFromResourcesToSlot();

            _timer.Reset();
        }


        private void ReturnResourceFromGrabber()
        {
            _resourceStorage.Add(out _, _grabber.ToArray());

            _grabber.Clear();
        }


        private void ConvertResourcesAndPutToProductSlot()
        {
            for (var i = 0; i < _productPerConversion; i++)
            {
                _productStorage.Add(out _, new TProduct());
            }

            _grabber.Clear();
        }


        private void LoadFromResourcesToSlot()
        {
            var resources = _resourceStorage.Get(_grabber.Capacity).ToArray();

            _grabber.Add(out _, resources);
        }
    }
}