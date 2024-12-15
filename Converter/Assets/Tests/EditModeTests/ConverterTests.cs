using System;
using NUnit.Framework;
using static Tests.EditModeTests.ConverterTestCaseDataProvider;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class ConverterTests
    {
        [TestCaseSource(typeof(ConverterTestCaseDataProvider), nameof(UpdateAutomaticallyCases))]
        public Tuple<bool, int, int> UpdateCycle(Feature.Converter<int, float> converter, float dt)
        {
            converter.Update(dt);

            return Tuple.Create(converter.IsLocked, converter.ResourceCount, converter.ProductCount);
        }


        [TestCaseSource(typeof(ConverterTestCaseDataProvider), nameof(AddProductToStorageCases))]
        public Tuple<bool, int> AddProduct(Feature.Converter<int, float> converter, float dt)
        {
            converter.Update(dt);

            return Tuple.Create(converter.IsLocked, converter.ProductCount);
        }


        [TestCaseSource(typeof(ConverterTestCaseDataProvider), nameof(GrabResourcesFromStorageCases))]
        public Tuple<bool, int> GrabResources(Feature.Converter<int, float> converter, float dt)
        {
            converter.Update(dt);

            return Tuple.Create(converter.IsLocked, converter.ResourceCount);
        }


        [TestCaseSource(typeof(ConverterTestCaseDataProvider), nameof(AddResourcesToEmptyStorageCases))]
        [TestCaseSource(typeof(ConverterTestCaseDataProvider), nameof(AddResourcesToNonEmptyStorageCases))]
        public Tuple<bool, int, int> AddResources(Feature.Converter<int, float> converter, int amount)
        {
            var success = converter.AddResources(amount, out var giveBack);
            var resourcesInStorage = converter.ResourceCount;

            return Tuple.Create(success, resourcesInStorage, giveBack);
        }


        [TestCase(5, 3, 0, 3, true)]
        [TestCase(5, 5, 0, 5, true)]
        [TestCase(5, 0, 0, 0, false)]
        [TestCase(5, -2, 0, 0, false)]
        [TestCase(3, 5, 2, 3, false)]
        public void ConverterStorage_Add(int storageCapacity,
                                         int amount,
                                         int expectedGiveBack,
                                         int expectedCount,
                                         bool expectedSuccess)
        {
            //Arrange:
            var storage = new Feature.Converter<int, float>.Storage(storageCapacity);

            //Act:
            var success = storage.Add(amount, out var giveBack);

            //Assert:
            Assert.AreEqual(expectedSuccess, success);
            Assert.AreEqual(expectedGiveBack, giveBack);
            Assert.AreEqual(storage.Count, expectedCount);
        }


        [Test]
        public void Constructor_Initialize_NotNull()
        {
            var converter = new Feature.Converter<int, float>();

            Assert.IsNotNull(converter);
        }
    }
}