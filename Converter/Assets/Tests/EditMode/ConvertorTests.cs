using System;
using Converter;
using NUnit.Framework;
using Tests.EditMode.Stubs;


namespace Tests.EditMode
{
    [TestFixture]
    public class ConvertorTests
    {
        private Convertor<StubLog, StubPlank> _defaultConvertor;


        [SetUp]
        public void Setup()
        {
            _defaultConvertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1, 1f);
        }


        [Test]
        public void Update_InterruptingCycleWithLoadingNewResources_ShouldBurnGrabbedResource()
        {
            var convertor = new Convertor<StubLog, StubPlank>(5, 3, 2, 1, 1f);

            var logs = StubFactory.Create<StubLog>(4);
            var additional = StubFactory.Create<StubLog>(5);

            convertor.AddResourcesToStorage(logs);

            convertor.Start();

            convertor.Update(1f);
            Assert.AreEqual(0, convertor.ResourcesCount);
            Assert.AreEqual(1, convertor.ProductsCount);
            Assert.AreEqual(2, convertor.GrabbedCount);

            convertor.Update(0.5f);
            Assert.AreEqual(0, convertor.ResourcesCount);
            Assert.AreEqual(1, convertor.ProductsCount);
            Assert.AreEqual(2, convertor.GrabbedCount);

            convertor.AddResourcesToStorage(additional);

            Assert.AreEqual(5, convertor.ResourcesCount);
            Assert.AreEqual(1, convertor.ProductsCount);
            Assert.AreEqual(2, convertor.GrabbedCount);

            convertor.Stop();

            Assert.AreEqual(5, convertor.ResourcesCount);
            Assert.AreEqual(1, convertor.ProductsCount);
            Assert.AreEqual(0, convertor.GrabbedCount);
        }


        [Test]
        public void Update_InterruptingCycle_StorageCountsShouldNotBeUpdated()
        {
            var convertor = new Convertor<StubLog, StubPlank>(3, 3, 1, 1, 1f);
            var logs = StubFactory.Create<StubLog>(3);

            convertor.AddResourcesToStorage(logs);

            convertor.Start();

            convertor.Update(0.5f);
            Assert.AreEqual(2, convertor.ResourcesCount);
            Assert.AreEqual(0, convertor.ProductsCount);
            Assert.AreEqual(1, convertor.GrabbedCount);

            convertor.Update(0.5f);
            Assert.AreEqual(1, convertor.ResourcesCount);
            Assert.AreEqual(1, convertor.ProductsCount);
            Assert.AreEqual(1, convertor.GrabbedCount);

            convertor.Update(1f);
            Assert.AreEqual(0, convertor.ResourcesCount);
            Assert.AreEqual(2, convertor.ProductsCount);
            Assert.AreEqual(1, convertor.GrabbedCount);

            convertor.Stop();

            convertor.Update(1f);
            Assert.AreEqual(1, convertor.ResourcesCount);
            Assert.AreEqual(2, convertor.ProductsCount);
            Assert.AreEqual(0, convertor.GrabbedCount);

            convertor.Update(1f);
            Assert.AreEqual(1, convertor.ResourcesCount);
            Assert.AreEqual(2, convertor.ProductsCount);
            Assert.AreEqual(0, convertor.GrabbedCount);
        }


        [Test]
        public void Update_UpdateCycle_CountsShouldBeCorrect()
        {
            var convertor = new Convertor<StubLog, StubPlank>(3, 3, 1, 1, 1f);
            var logs = StubFactory.Create<StubLog>(3);

            convertor.AddResourcesToStorage(logs);

            Assert.AreEqual(3, convertor.ResourcesCount);
            Assert.AreEqual(0, convertor.ProductsCount);

            convertor.Start();
            //cycle 0
            convertor.Update(0f);
            Assert.AreEqual(2, convertor.ResourcesCount);
            Assert.AreEqual(0, convertor.ProductsCount);
            Assert.AreEqual(1, convertor.GrabbedCount);
            //cycle 0: repeats because of dt == 0f
            convertor.Update(0f);
            Assert.AreEqual(2, convertor.ResourcesCount);
            Assert.AreEqual(0, convertor.ProductsCount);
            Assert.AreEqual(1, convertor.GrabbedCount);
            //cycle 1
            convertor.Update(1.0f);
            Assert.AreEqual(1, convertor.ResourcesCount);
            Assert.AreEqual(1, convertor.ProductsCount);
            Assert.AreEqual(1, convertor.GrabbedCount);
            //cycle 2
            convertor.Update(1.0f);
            Assert.AreEqual(0, convertor.ResourcesCount);
            Assert.AreEqual(2, convertor.ProductsCount);
            Assert.AreEqual(1, convertor.GrabbedCount);
            //cycle 3 - resources are empty, products are full
            convertor.Update(1.0f);
            Assert.AreEqual(0, convertor.ResourcesCount);
            Assert.AreEqual(3, convertor.ProductsCount);
            Assert.AreEqual(0, convertor.GrabbedCount);

            //converter is still working
            Assert.IsTrue(convertor.IsActive);
        }


        [Test]
        public void AddResourcesToStorage_AddNullToResourceStorage_ExpectFalse()
        {
            var convertor = new Convertor<StubLog, StubPlank>(5, 1, 1, 1, 1f);

            var success = convertor.AddResourcesToStorage(null);

            Assert.IsFalse(success);
        }


        [Test]
        [TestCase(5, 5, 5, true)]
        [TestCase(5, 10, 5, false)]
        [TestCase(5, 2, 2, true)]
        [TestCase(5, 0, 0, false)]
        public void AddResourcesToStorage_AddResourcesToResourceStorage_ResourceCounterShoudBeChanged(
            int resourceStorageCapacity,
            int resourceCount,
            int expectedCount,
            bool expectedSuccess)
        {
            var convertor = new Convertor<StubLog, StubPlank>(resourceStorageCapacity, 1, 1, 1, 1f);

            var logs = StubFactory.Create<StubLog>(resourceCount);

            var success = convertor.AddResourcesToStorage(logs);

            Assert.AreEqual(convertor.ResourcesCount, expectedCount);
            Assert.AreEqual(success, expectedSuccess);
        }


        [Test]
        public void Start_StartProcessing_IsActiveStateTrue()
        {
            var convertor = _defaultConvertor;
            convertor.Start();
            Assert.IsTrue(convertor.IsActive);
        }


        [Test]
        public void Stop_StopProcessing_IsActiveStateFalse()
        {
            var convertor = _defaultConvertor;
            convertor.Stop();
            Assert.IsFalse(convertor.IsActive);
        }


        [Test]
        [TestCase(-1, 1, 1, 1, 1f)]
        [TestCase(1, -1, 1, 1, 1f)]
        [TestCase(1, 1, -1, 1, 1f)]
        [TestCase(1, 1, 1, -1, 1f)]
        [TestCase(1, 1, 1, 1, -1f)]
        public void Constructor_InitializeWithNgativeParameters_ThrowsException(int resourceStorageCapacity,
            int productStorageCapacity,
            int loadAmount,
            int unloadAmount,
            float processingTime)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Convertor<StubLog, StubPlank>(
                                                             resourceStorageCapacity,
                                                             productStorageCapacity,
                                                             loadAmount,
                                                             unloadAmount,
                                                             processingTime));
        }


        [Test]
        public void Constructor_InitializeWithValidParameters_ExpectNotNull()
        {
            Assert.IsNotNull(_defaultConvertor);
        }
    }
}