using System;
using System.Linq;
using Converter;
using NUnit.Framework;
using Tests.EditMode.Stubs;

namespace Tests.EditMode
{
    [TestFixture]
    public class StorageTests
    {
        [Test]
        [TestCase(10, 5, 3, 3, 2)]
        [TestCase(10, 5, 5, 5, 0)]
        [TestCase(10, 3, 5, 3, 0)]
        [TestCase(10, 5, 0, 0, 5)]
        [TestCase(10, 5, -3, 0, 5)]
        public void Get_GetItemsFromStorage_CountIsValid(int storageCapacity,
                                                         int countToLoad,
                                                         int countToGet,
                                                         int expectedToGet,
                                                         int expectedToRemain)
        {
            var storage = new Storage<StubLog>(storageCapacity);

            var items = StubFactory.Create<StubLog>(countToLoad);

            _ = storage.Add(out _, items);

            Assert.AreEqual(storage.Count, countToLoad);

            var get = storage.Get(countToGet).ToArray();

            Assert.AreEqual(get.Length, expectedToGet);
            Assert.AreEqual(storage.Count, expectedToRemain);
        }


        [Test]
        public void GetSingle_GetSingleItemFromEmptyStorage_ExpectFalseAndNull()
        {
            var storage = new Storage<StubLog>(10);

            var items = Array.Empty<StubLog>();

            var add = storage.Add(out _, items);

            Assert.IsFalse(add);
            Assert.AreEqual(storage.Count, 0);

            var get = storage.GetSingle(out var item);

            Assert.IsFalse(get);
            Assert.IsNull(item);
        }


        [Test]
        public void GetSingle_GetSingleItemFromFilledStorage_ExpectTrueAndNotNull()
        {
            var storage = new Storage<StubLog>(10);

            var first = new StubLog();

            _ = storage.Add(out _, first);

            Assert.AreEqual(storage.Count, 1);

            var get = storage.GetSingle(out var item);

            Assert.IsTrue(get);
            Assert.IsNotNull(item);
            Assert.AreEqual(first, item);
        }


        [Test]
        public void GetAll_GetAllItemsFromStorage_CountIsValid()
        {
            var storage = new Storage<StubLog>(10);

            var first = new StubLog();
            var second = new StubLog();
            var third = new StubLog();

            var items = new[] { first, second, third };

            _ = storage.Add(out _, items);

            Assert.AreEqual(storage.Count, 3);

            var get = storage.GetAll().ToArray();

            Assert.AreEqual(get.Length, 3);

            Assert.IsTrue(get.Contains(first) &&
                          get.Contains(second) &&
                          get.Contains(third));
        }


        [Test]
        public void OnFull_CallOnFullEvent_ExpectInvoked()
        {
            var storage = new Storage<StubLog>(3);

            var isFull = false;

            storage.OnFull += () => isFull = true;

            var items = StubFactory.Create<StubLog>(3);

            _ = storage.Add(out _, items);

            Assert.AreEqual(storage.Count, 3);

            Assert.IsTrue(isFull);
        }


        [Test]
        public void Clear_ClearStorage_CountZero()
        {
            var storage = new Storage<StubLog>(10);

            var items = StubFactory.Create<StubLog>(10);

            _ = storage.Add(out _, items);

            Assert.AreEqual(storage.Count, 10);

            storage.Clear();

            Assert.AreEqual(storage.Count, 0);
        }


        [Test]
        public void Add_AddDoublesAndNulls_ExpectEnqueueWithoutDoublesAndNulls()
        {
            var storage = new Storage<StubLog>(10);

            var first = new StubLog();
            var second = new StubLog();
            var third = new StubLog();

            var items = new[]
            {
                first, null, second, first, third, null
            };

            var add = storage.Add(out var overloads, items);

            Assert.IsTrue(add);
            Assert.AreEqual(overloads.Count, 0);
            Assert.AreEqual(storage.Count, 3);

            Assert.IsTrue(storage.Contains(first) &&
                          storage.Contains(second) &&
                          storage.Contains(third));
        }


        [TestCase(3, 10, 3, 7)]
        [TestCase(3, 0, 0, 0)]
        public void Add_ValidObjectsWithOverloadsOrZero_ExpectFalse(int capacity,
                                                                    int count,
                                                                    int expectedStorageCount,
                                                                    int expectedOverloadCount)
        {
            var storage = new Storage<StubLog>(capacity);

            var items = StubFactory.Create<StubLog>(count);

            var add = storage.Add(out var overloads, items);

            Assert.IsFalse(add);
            Assert.AreEqual(overloads.Count, expectedOverloadCount);
            Assert.AreEqual(storage.Count, expectedStorageCount);
        }


        [TestCase(3, 3, 3, 0)]
        [TestCase(3, 1, 1, 0)]
        public void Add_ValidObjects_ExpectCorrectCount(int capacity,
                                                        int count,
                                                        int expectedStorageCount,
                                                        int expectedOverloadCount)
        {
            var storage = new Storage<StubLog>(capacity);

            var items = StubFactory.Create<StubLog>(count);

            var add = storage.Add(out var overloads, items);

            Assert.IsTrue(add);
            Assert.AreEqual(overloads.Count, expectedOverloadCount);
            Assert.AreEqual(storage.Count, expectedStorageCount);
        }


        [Test]
        public void Add_NullReference_ExpectFalse()
        {
            var storage = new Storage<StubLog>(10);

            var add = storage.Add(out _, null);

            Assert.IsFalse(add);
            Assert.AreEqual(storage.Count, 0);
        }


        [Test]
        public void Constructor_InitializeWithNegativeValue_ExpectException()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Storage<StubLog>(-3));
        }


        [TestCase(0)]
        [TestCase(3)]
        public void Constructor_InitializeWithPositiveValue_ExpectNotNull(int capacity)
        {
            var storage = new Storage<StubLog>(3);

            Assert.IsNotNull(storage);
        }
    }
}