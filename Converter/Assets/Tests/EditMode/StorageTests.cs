using System;
using System.Linq;
using Converter;
using NUnit.Framework;
using Tests.Stubs;

namespace Tests.EditMode
{
    [TestFixture]
    public class StorageTests
    {
        [Test]
        public void Storage_Initialize_NotNull()
        {
            var storage = new Storage<StubLog>(1);

            Assert.IsNotNull(storage, "Storage is not null");
        }


        [Test]
        public void Storage_InitializeWithInvalidParameters_ThrowsException()
        {
            const int value = -1;

            Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Storage<StubLog>(value),
                                                      $"<{value}> :: Invalid parameter");
        }


        [Test]
        [TestCase(5, 3, 0, 0, 3)]
        [TestCase(5, 3, 2, 2, 1)]
        [TestCase(5, 3, 5, 3, 0)]
        [TestCase(5, 3, 3, 3, 0)]
        [TestCase(5, 3, -3, 0, 3)]
        public void GetResources_ProvideResources_GetExpectedAmount(int storageCapacity,
                                                                    int availableAmount,
                                                                    int requestedAmount,
                                                                    int expectedAmount,
                                                                    int expectedRemainedAmount)
        {
            var storage = new Storage<StubLog>(storageCapacity);

            var resources = new StubLog[availableAmount];

            for (var i = 0; i < availableAmount; i++)
            {
                resources[i] = new StubLog();
            }

            storage.AddResources(resources);

            var result = storage.GetResources(requestedAmount);

            Assert.IsNotNull(result, "Result should not be null");

            var resultAmount = result.Count();

            Assert.IsTrue(resultAmount == expectedAmount,
                          $"Expected {expectedAmount} but was {resultAmount}");

            Assert.IsTrue(expectedRemainedAmount == storage.Count,
                          $"Expected {expectedRemainedAmount} but was {storage.Count}");
        }


        [Test]
        public void AddResources_AddObjectsToStorage_ShouldAddCorrectly()
        {
            var capacity = 3;
            var storage = new Storage<StubLog>(capacity);

            var first = new StubLog();
            var second = new StubLog();
            var third = new StubLog();
            var fourth = new StubLog();

            var resources = new[]
            {
                first, null, second,
                first, third, fourth
            };

            storage.AddResources(resources);

            Assert.Catch<ArgumentNullException>(() => storage.AddResources(null), "Value cannot be null.");
            Assert.That(storage.Count, Is.EqualTo(capacity), "Count should be equal to max capacity.");

            Assert.IsTrue(storage.Contains(first), $"Should contain {first} item.");
            Assert.IsTrue(storage.Contains(second), $"Should contain {second} item.");
            Assert.IsTrue(storage.Contains(third), $"Should contain {third} item.");

            Assert.IsFalse(storage.Contains(fourth), $"Should not contain {fourth} item.");
        }
    }
}