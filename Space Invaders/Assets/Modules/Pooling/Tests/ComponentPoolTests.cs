using Modules.Pooling.Scripts;
using NUnit.Framework;
using Tests.PlayMode;
using UnityEngine;

namespace Modules.Pooling.Tests
{
    public class ComponentPoolTests
    {
        private MonoBehaviourStub _prefab;
        private Transform _parent;

        [SetUp]
        public void Setup()
        {
            _prefab = new GameObject().AddComponent<MonoBehaviourStub>();
            _parent = new GameObject().transform;
        }

        [Test]
        public void Count_OnRentAndReleaseItem_ResultShouldBeTrue()
        {
            var startCount = 3;
            var pool = new ComponentPool<MonoBehaviourStub>(_prefab, _parent, startCount);

            var item = pool.Rent();

            var rentSuccess = pool.Count == startCount - 1;

            pool.Return(item);

            var returnSuccess = pool.Count == startCount;

            Assert.IsTrue(rentSuccess, "Rent should be true.");
            Assert.IsTrue(returnSuccess, "Return should be true.");
        }

        [Test]
        public void ObjectPool_RentItemWithNullParent_ShouldUseVector3_Zero()
        {
            var pool = new ComponentPool<MonoBehaviourStub>(_prefab, null, 3);

            var item = pool.Rent();

            Assert.That(item.transform.position, Is.EqualTo(Vector3.zero), "Item should not be null.");
        }

        [Test]
        public void ObjectPool_RentItem_ShouldBeNotNull()
        {
            var pool = new ComponentPool<MonoBehaviourStub>(_prefab, _parent, 3);
        
            var item = pool.Rent();
        
            Assert.IsNotNull(item, "Item should not be null.");
            
            Debug.Log("3");
        }
        
        
        [Test]
        public void ObjectPool_InitializeWithNullPrefabArgument_ShouldThrowArgumentNullException()
        {
            Assert.That(() => _ = new ComponentPool<MonoBehaviourStub>(null, _parent), Throws.ArgumentNullException,
                "Throws when prefab is null.");
            Debug.Log("2");
        }

        [TestCase(3, 3)]
        [TestCase(-3, 0)]
        [TestCase(0, 0)]
        public void ObjectPool_Initialize_ShouldBeNotNullAndFilledByItems(int poolCapacity, int expectedCount)
        {
            var pool = new ComponentPool<MonoBehaviourStub>(_prefab, _parent, poolCapacity);

            Assert.IsNotNull(pool, "Object pool should not be null.");

            Assert.That(pool.Count, Is.EqualTo(expectedCount),
                "Object pool count should be equal the poolCapacity value.");
            Debug.Log("1");
        }
    }
}