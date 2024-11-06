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
        private Func<MonoBehaviourStub> _creatCallback;

        [SetUp]
        public void Setup()
        {
            _creatCallback = () => new GameObject().AddComponent<MonoBehaviourStub>();
        }

        [Test]
        public void Count_OnRentAndReleaseItem_ResultShouldBeTrue()
        {
            var startCount = 3;
            var pool = new ComponentPool<MonoBehaviourStub>(_creatCallback, startCount);

            var item = pool.Rent();

            var rentSuccess = pool.Count == startCount - 1;

            pool.Return(item);

            var returnSuccess = pool.Count == startCount;

            Assert.IsTrue(rentSuccess, "Rent should be true.");
            Assert.IsTrue(returnSuccess, "Return should be true.");
        }
       

        [Test]
        public void ObjectPool_RentItem_ShouldBeNotNull()
        {
            var pool = new ComponentPool<MonoBehaviourStub>(_creatCallback, 3);

            var item = pool.Rent();

            Assert.IsNotNull(item, "Item should not be null.");
        }


      

        [TestCase(3, 3)]
        [TestCase(-3, 0)]
        [TestCase(0, 0)]
        public void ObjectPool_Initialize_ShouldBeNotNullAndFilledByItems(int poolCapacity, int expectedCount)
        {
            var pool = new ComponentPool<MonoBehaviourStub>(_creatCallback, poolCapacity);

            Assert.IsNotNull(pool, "Object pool should not be null.");

            Assert.That(pool.Count, Is.EqualTo(expectedCount),
                "Object pool count should be equal the poolCapacity value.");
        }
    }
}