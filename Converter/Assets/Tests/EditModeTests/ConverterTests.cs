using System.Collections.Generic;
using NUnit.Framework;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class ConverterTests
    {
        [TestCaseSource(nameof(AddResources_ToNonEmptyStorage_GiveBackCases))]
        public int AddResources_ToNonEmptyStorage_GiveBack(Feature.Converter<int, float> converter, int amount)
        {
            _ = converter.AddResources(amount, out var giveBack);

            return giveBack;
        }


        private static IEnumerable<TestCaseData> AddResources_ToNonEmptyStorage_GiveBackCases()
        {
            //Create non-empty converter:
            Feature.Converter<int, float> CreateConverter(int capacity, int amount)
            {
                var converter = new Feature.Converter<int, float>(resourceStorageCapacity: capacity);
                converter.AddResources(amount, out _);

                return converter;
            }

            //Cases:
            yield return new TestCaseData(CreateConverter(5, 2), 1)
                         .Returns(0)
                         .SetName("Storage was 2/5, add 1, giveback 0");

            yield return new TestCaseData(CreateConverter(5, 2), 3)
                         .Returns(0)
                         .SetName("Storage was 2/5, add 3, giveback 0");

            yield return new TestCaseData(CreateConverter(5, 2), 4)
                         .Returns(1)
                         .SetName("Storage was 2/5, add 4, giveback 1");
        }


        [TestCaseSource(nameof(AddResources_ToEmptyStorage_GiveBackCases))]
        public int AddResources_ToEmptyStorage_GiveBack(Feature.Converter<int, float> converter, int amount)
        {
            _ = converter.AddResources(amount, out var giveBack);

            return giveBack;
        }


        private static IEnumerable<TestCaseData> AddResources_ToEmptyStorage_GiveBackCases()
        {
            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), 3)
                         .Returns(0)
                         .SetName("Storage is 0/5, add 3, giveback 0");

            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), 5)
                         .Returns(0)
                         .SetName("Storage is 0/5, add 5, giveback 0");

            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 3), 5)
                         .Returns(2)
                         .SetName("Storage is 0/3, add 5, , giveback 2");
        }


        [TestCaseSource(nameof(AddResources_ToStorageCases))]
        public bool AddResources_ToStorage(Feature.Converter<int, float> converter, int amount)
        {
            return converter.AddResources(amount, out _);
        }


        private static IEnumerable<TestCaseData> AddResources_ToStorageCases()
        {
            //true
            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), 3)
                         .Returns(true)
                         .SetName("Storage is 5, add 3");

            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), 5)
                         .Returns(true)
                         .SetName("Storage is 5, add 5");

            //false
            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), 0)
                         .Returns(false)
                         .SetName("Storage is 5, add 0");

            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), -1)
                         .Returns(false)
                         .SetName("Storage is 5, add -1");

            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 3), 5)
                         .Returns(false)
                         .SetName("Storage is 3, add 5");
        }


        [Test]
        public void Update_OnTimerReset_ShouldRaiseEvent()
        {
            //Arrange:
            var time = 1f;
            var converter = new Feature.Converter<int, float>(1, 1, 1, 1, time);

            bool eventRaised = false;

            converter.OnTimerReset += () => eventRaised = true;

            //Act:
            converter.Update(time);

            //Assert:
            Assert.IsTrue(eventRaised);
        }


        [Test]
        public void Constructor_Initialize_NotNull()
        {
            var converter = new Feature.Converter<int, float>(5, 5, 5, 5, 5f);

            Assert.IsNotNull(converter);
        }
    }
}