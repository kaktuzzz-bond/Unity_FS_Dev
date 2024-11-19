using System;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceConverter
{
    public class Convertor<TResource, TProduct> where TResource : class
                                                where TProduct : class, new()
    {
        public bool IsActive { get; private set; }
        public int ResourceCount => _resourceStorage.Count;
        public int ProductCount => _productCounter + 1;

        private readonly TProduct[] _productStorage;
        private readonly TResource[] _grabber;
        private readonly int _productPerResource;
        private readonly float _processingTime;

        private readonly Queue<TResource> _resourceStorage = new();
        private int _productCounter = -1;
        private float _timeCounter;


        public Convertor(int convertorCapacity,
                         int productStorageCapacity,
                         int productPerResource,
                         float processingTime)
        {
            if (convertorCapacity < 0)
                throw new ArgumentOutOfRangeException(nameof(convertorCapacity), convertorCapacity,
                                                      "The convertorCapacity cannot be negative.");

            if (productStorageCapacity < 0)
                throw new ArgumentOutOfRangeException(nameof(productStorageCapacity), convertorCapacity,
                                                      "The productStorageCapacity cannot be negative.");

            if (productPerResource < 0)
                throw new ArgumentOutOfRangeException(nameof(productPerResource), convertorCapacity,
                                                      "The productPerResource cannot be negative.");

            if (processingTime < 0)
                throw new ArgumentOutOfRangeException(nameof(processingTime), convertorCapacity,
                                                      "The timePerLoad cannot be negative.");

            _grabber = new TResource[convertorCapacity];
            _productStorage = new TProduct[productStorageCapacity];
            _productPerResource = productPerResource;
            _processingTime = processingTime;
        }


        public int Add(params TResource[] resources)
        {
            if (resources == null)
                throw new ArgumentNullException(nameof(resources), "Resources cannot be null");

            if (resources.Length == 0) return 0;

            foreach (var resource in resources)
            {
                if (resource == null ||
                    _resourceStorage.Contains(resource))
                    continue;

                _resourceStorage.Enqueue(resource);
            }

            return _resourceStorage.Count;
        }


        public void Start()
        {
            IsActive = true;
        }


        public void Stop()
        {
            IsActive = false;
        }


        public void Update(float dt)
        {
            if (!IsActive) return;

            _timeCounter -= dt;

            Debug.Log($"Update: {_timeCounter}");

            if (_timeCounter > 0f) return;

            Grab();

            var converted = Convert();

            PlaceToProductStorage(converted);

            ResetTimer();
        }


        private void Grab()
        {
            for (var i = 0; i < _grabber.Length; i++)
            {
                if (_resourceStorage.TryDequeue(out var resource))
                    _grabber[i] = resource;
            }
        }


        private void PlaceToProductStorage(params TProduct[] products)
        {
            foreach (var product in products)
            {
                _productCounter++;

                if (_productCounter > _productStorage.Length)
                    throw new
                        InvalidOperationException($"The product counter is out of range {_productCounter} : {_productStorage.Length}");

                if (_productCounter == _productStorage.Length)
                {
                    Stop();

                    return;
                }

                _productStorage[_productCounter] = product;
            }
        }


        private TProduct[] Convert()
        {
            var products = Array.Empty<TProduct>();

            for (var i = 0; i < _grabber.Length; i++)
            {
                if (_grabber[i] == null) continue;

                var converted = ConvertResourceToProduct(_grabber[i]);

                _grabber[i] = null;

                var length = products.Length;

                Array.Resize(ref products, length + converted.Length);
                Array.Copy(converted, 0, products, length, converted.Length);
            }

            return products;
        }


        private TProduct[] ConvertResourceToProduct(TResource resource)
        {
            var products = new TProduct[_productPerResource];

            for (var i = 0; i < products.Length; i++)
            {
                products[i] = new TProduct();
            }

            return products;
        }


        private void ResetTimer()
        {
            _timeCounter = _processingTime;
        }
    }
}