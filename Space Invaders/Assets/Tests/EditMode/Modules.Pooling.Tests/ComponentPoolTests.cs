using System;
using Modules.Pooling;
using NUnit.Framework;
using Tests.PlayMode.Fakes;
using UnityEngine;


namespace Tests.EditMode.Modules.Pooling.Tests
{
    [TestFixture]
    public class ComponentPoolTests
    {
        private Func<MonoStub> _creatCallback;
        
        [SetUp]
        public void Setup()
        {
            _creatCallback = () => new GameObject().AddComponent<MonoStub>();
        }

        [Test]
        public void ComponentPool_OnRentAndReleaseItem_ResultShouldBeTrue()
        {
            const int startCount = 3;

            var pool = new ComponentPool<MonoStub>(_creatCallback, startCount);

            var item = pool.Rent();

            var rentSuccess = pool.Count == startCount - 1;

            pool.Return(item);

            var returnSuccess = pool.Count == startCount;

            Assert.IsTrue(rentSuccess, "Rent should be true.");
            Assert.IsTrue(returnSuccess, "Return should be true.");
            Assert.IsTrue(pool.Count == startCount, "Count should be the same.");
            Assert.IsFalse(item.gameObject.activeSelf, "Returned item should be deactivated.");
        }

        [Test]
        public void ComponentPool_OnReturnNull_ThrowArgumentNullException()
        {
            var pool = new ComponentPool<MonoStub>(_creatCallback, 3);

            Assert.That(() => pool.Return(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ComponentPool_RentItem_NotNull()
        {
            var pool = new ComponentPool<MonoStub>(_creatCallback, 3);

            var item = pool.Rent();

            Assert.IsNotNull(item, "Item should not be null.");
            Assert.IsTrue(item.gameObject.activeSelf, "Item should be active.");
        }

        [Test]
        public void ComponentPool_InitializeWitheNullDelegate_ThrowArgumentNullException()
        {
            Assert.That(() => _ = new ComponentPool<MonoStub>(null, 3), Throws.ArgumentNullException);
        }

        [TestCase(3, 3)]
        [TestCase(-3, 0)]
        [TestCase(0, 0)]
        public void ComponentPool_Initialize_NotNullAndFilledByItems(int poolCapacity, int expectedCount)
        {
            var pool = new ComponentPool<MonoStub>(_creatCallback, poolCapacity);

            Assert.IsNotNull(pool, "Object pool should not be null.");

            Assert.That(pool.Count, Is.EqualTo(expectedCount),
                "Object pool count should be equal the poolCapacity value.");
        }
        
    }
    
    
}