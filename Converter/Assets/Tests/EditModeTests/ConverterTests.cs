using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class ConverterTests
    {
        [TestCaseSource(nameof(Update_SimulateRuntimeCases))]
        public Tuple<bool, int, int> Update_SimulateRuntime(Feature.Converter<int, float> converter, float deltaTime)
        {
            /*
             * 1. конвертер грабает ресурс (если может)
             * 2. конвертер блокируется ==> включается таймер
             * 3. таймер заканчивается ==> проверяем, можем ли выгрузить ресурсы
             * 4. если можем ==> выгружаем ==> разблокируем конвертер
             */
            
            converter.Update(deltaTime);
            var isLocked = converter.IsLocked;
            var resourceCount = converter.ResourceCount;
            var productCount = converter.ProductCount;

            return Tuple.Create(isLocked, resourceCount, productCount);
        }

        
        private static IEnumerable<TestCaseData> Update_SimulateRuntimeCases()
        {
            //create empty converter
            var converter = new Feature.Converter<int, float>(resourceStorageCapacity: 5,
                                                              productStorageCapacity: 5,
                                                              resourceGrabValue: 2,
                                                              productPerLoadValue: 3,
                                                              produceTime: 0.9f);

            yield return new TestCaseData(converter, 0.1f)
                         .Returns(Tuple.Create(false, 0, 0))
                         .SetName("Converter does not have resources");
            
            // //add resources to storage (3/5 now)
            // _ = converter.AddResources(3, out _);
            
            // yield return new TestCaseData(converter, 0.1f)
            //              .Returns(Tuple.Create(true, 1, 0))
            //              .SetName("Converter grabbed 2 resources and is locked, timer starts");
            //
            // //timer 1 started
            // yield return new TestCaseData(converter, 0.5f)
            //              .Returns(Tuple.Create(true, 1, 0))
            //              .SetName("Converter is locked, resources are being processed [1]");
            //
            // //timer 1 finished
            // yield return new TestCaseData(converter, 0.5f)
            //              .Returns(Tuple.Create(false, 1, 3))
            //              .SetName("Converter completed the process, is unlocked, 3 products added to product storage");
            //
            // yield return new TestCaseData(converter, 0.5f)
            //              .Returns(Tuple.Create(false, 1, 3))
            //              .SetName("Converter is still unlocked, it does not have enough resources (1 of 2)");
            //
            // //add resources to storage (2/5 now)
            // _ = converter.AddResources(1, out _);
            //
            // yield return new TestCaseData(converter, 0.1f)
            //              .Returns(Tuple.Create(true, 0, 3))
            //              .SetName("Converter grabbed 2 resources and is locked");
            //
            // //timer 2 started
            // //add resources to storage (3/5 now)
            // _ = converter.AddResources(3, out _);
            //
            // yield return new TestCaseData(converter, 0.5f)
            //              .Returns(Tuple.Create(true, 3, 3))
            //              .SetName("Converter is locked, resources are being processed [2]");
            //
            // //timer 2 finished
            // yield return new TestCaseData(converter, 0.5f)
            //              .Returns(Tuple.Create(true, 3, 3))
            //              .SetName("Converter is locked, product (3/5 in the storage, 2 is free, but 3 needed)");
        }


        [Test]
        public void OnProductProduced_PutProductToStorage_ShouldRaiseEventAndAndCountBeChanged()
        {
            //Arrange:
            var converter =
                new Feature.Converter<int, float>(resourceStorageCapacity: 5, productStorageCapacity: 5,
                                                  productPerLoadValue: 2,
                                                  produceTime: 0.5f);
            _ = converter.AddResources(amount: 5, out _);

            //Act:
            converter.Update(0.5f);

            //Assert:
            Assert.IsFalse(converter.IsLocked, "Product produced: converter should be free");

            Assert.AreEqual(converter.ProductCount, 2,
                            "Product produced: converter product count should be equal to 2");
        }


        [Test]
        public void OnGrabbed_TryGrabResourcesFromStorageWhenNotEnough_ShouldDoNothing()
        {
            //Arrange:
            var converter = new Feature.Converter<int, float>(resourceStorageCapacity: 5, resourceGrabValue: 2);
            _ = converter.AddResources(amount: 1, out _);

            //Act:
            converter.Update(0.5f);

            //Assert:
            Assert.IsFalse(converter.IsLocked, "Resources were NOT grabbed: converter should be free");

            Assert.AreEqual(converter.ResourceCount, 1,
                            "Not enough resources: resource count should be equal to 1");
        }


        [Test]
        public void OnGrabbed_GrabResourcesFromStorage_ShouldRaiseEventAndCountChanged()
        {
            //Arrange:
            var converter = new Feature.Converter<int, float>(resourceStorageCapacity: 5,
                                                              resourceGrabValue: 2);
            _ = converter.AddResources(amount: 2, out _);
            
            //Act:
            converter.Update(0.5f);

            //Assert:
            Assert.IsTrue(converter.IsLocked, "Resources were grabbed: converter should be locked");
            Assert.AreEqual(converter.ResourceCount, 0, "Resources grabbed: resource count should be equal to 0");
        }


        [TestCaseSource(nameof(ResourceCount_ResourceCount_ShouldBeChangedOnAddCases))]
        public int ResourceCount_ResourceCount_ShouldBeChangedOnAdd(Feature.Converter<int, float> converter, int amount)
        {
            _ = converter.AddResources(amount, out _);

            return converter.ResourceCount;
        }


        private static IEnumerable<TestCaseData> ResourceCount_ResourceCount_ShouldBeChangedOnAddCases()
        {
            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), 3)
                         .Returns(3)
                         .SetName("Storage is 0/5, add 3, count 3");

            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 5), 5)
                         .Returns(5)
                         .SetName("Storage is 0/5, add 5, count 5");

            yield return new TestCaseData(
                                          new Feature.Converter<int, float>(resourceStorageCapacity: 3), 5)
                         .Returns(3)
                         .SetName("Storage is 0/3, add 5,  count 3");
        }


        [TestCaseSource(nameof(AddResources_ToNonEmptyStorage_GiveBackCases))]
        public int AddResources_ToNonEmptyStorage_GiveBack(Feature.Converter<int, float> converter, int amount)
        {
            _ = converter.AddResources(amount, out var giveBack);

            return giveBack;
        }


        private static IEnumerable<TestCaseData> AddResources_ToNonEmptyStorage_GiveBackCases()
        {
            Feature.Converter<int, float> CreateConverterWithResources(int capacity, int amount)
            {
                var converter = new Feature.Converter<int, float>(resourceStorageCapacity: capacity);
                converter.AddResources(amount, out _);

                return converter;
            }

            yield return new TestCaseData(CreateConverterWithResources(5, 2), 1)
                         .Returns(0)
                         .SetName("Storage was 2/5, add 1, giveback 0");

            yield return new TestCaseData(CreateConverterWithResources(5, 2), 3)
                         .Returns(0)
                         .SetName("Storage was 2/5, add 3, giveback 0");

            yield return new TestCaseData(CreateConverterWithResources(5, 2), 4)
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
        public void Constructor_Initialize_NotNull()
        {
            var converter = new Feature.Converter<int, float>();

            Assert.IsNotNull(converter);
        }
    }
}