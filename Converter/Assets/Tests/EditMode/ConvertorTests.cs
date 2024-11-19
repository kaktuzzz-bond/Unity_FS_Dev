using System;
using NUnit.Framework;
using ResourceConverter;
using Tests.EditMode.Stubs;


namespace Tests.EditMode
{
    [TestFixture]
    public class ConvertorTests
    {
        [Test]
        public void Update_ProcessResources_ResourceAndProductCountShouldBeChanged()
        {
            var convertor = new Convertor<StubLog, StubPlank>(5, 300, 10, 1f);
            var logs = CreateLogs(20);
            convertor.Add(logs);

            convertor.Start();

            convertor.Update(0.3f);
            convertor.Update(0.3f);
            convertor.Update(0.3f);
            convertor.Update(0.3f);
            convertor.Update(0.2f);

           
            Assert.AreEqual(convertor.ResourceCount, 10);
            Assert.AreEqual(convertor.ProductCount, 100);
           
        }


        [Test]
        public void Start_StartProcessing_IsActiveStateTrue()
        {
            var convertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1);
            convertor.Start();
            Assert.IsTrue(convertor.IsActive);
        }


        [Test]
        public void Stop_StopProcessing_IsActiveStateFalse()
        {
            var convertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1);
            convertor.Stop();
            Assert.IsFalse(convertor.IsActive);
        }


        [TestCase(5, 5, 5, 5.5f)]
        [TestCase(0, 0, 0, 0f)]
        public void Converter_Initialization_ShouldBeNotNull(int converterCapacity,
                                                             int storageCapacity,
                                                             int productPerResource,
                                                             float timePerLoad)
        {
            var convertor = new Convertor<StubLog, StubPlank>(converterCapacity,
                                                              storageCapacity,
                                                              productPerResource, timePerLoad);

            Assert.IsNotNull(convertor);
        }


        [TestCase(-5, 5, 5, 5.5f)]
        [TestCase(5, -5, 5, 5.5f)]
        [TestCase(5, 5, -5, 5.5f)]
        [TestCase(5, 5, 5, -5.5f)]
        public void Convertor_InitializationWithNegativeParameters_ShouldThrowException(int converterCapacity,
            int storageCapacity,
            int productPerResource,
            float timePerLoad)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Convertor<StubLog, StubPlank>(
                                                                 converterCapacity,
                                                                 storageCapacity,
                                                                 productPerResource, timePerLoad));
        }


        [Test]
        public void Add_AddResourcesWithNulls_ShouldBeAdded()
        {
            var convertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1);

            var logs = new StubLog[]
            {
                new(),
                null,
                new(),
            };

            var added = convertor.Add(logs);

            Assert.AreEqual(added, 2);
        }


        [Test]
        public void Add_AddResourcesWithDoubles_ShouldBeAdded()
        {
            var convertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1);

            var log = new StubLog();

            var logs = new StubLog[]
            {
                new(),
                log,
                log
            };

            var added = convertor.Add(logs);

            Assert.AreEqual(added, 2);
        }


        [Test]
        public void Add_AddNull_ShouldBeAdded()
        {
            var convertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1);

            Assert.Catch<ArgumentNullException>(() => _ = convertor.Add(null));
        }


        [Test]
        public void Add_AddEmpty_ShouldBeAdded()
        {
            var convertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1);

            var logs = new StubLog[] { };

            var added = convertor.Add(logs);

            Assert.AreEqual(added, 0);
        }


        private StubLog[] CreateLogs(int count)
        {
            var logs = new StubLog[count];

            for (var i = 0; i < count; i++)
                logs[i] = new StubLog();

            return logs;
        }
    }
}