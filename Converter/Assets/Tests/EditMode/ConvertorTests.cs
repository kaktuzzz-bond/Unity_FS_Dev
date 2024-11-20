using System;
using Converter;
using NUnit.Framework;
using Tests.EditMode.Stubs;


namespace Tests.EditMode
{
    [TestFixture]
    public class ConvertorTests
    {
        private Storage<StubLog> _resourceStorage;
        private Storage<StubPlank> _productStorage;


        [SetUp]
        public void Setup()
        {
            _resourceStorage = new Storage<StubLog>(20);
            _productStorage = new Storage<StubPlank>(300);
        }
        
        
        
        
        // private Convertor<StubLog, StubPlank> _defaultConverter;
        //
        //
        // [SetUp]
        // public void Setup()
        // {
        //     _defaultConverter = new Convertor<StubLog, StubPlank>(1, 1, 1, 1, 1);
        // }
        //
        //
        // [Test]
        // public void Update_ProcessResources_ResourceAndProductCountShouldBeChanged()
        // {
        //     var convertor = new Convertor<StubLog, StubPlank>(5, 300, 10, 50,1f);
        //     var logs = CreateLogs(20);
        //     convertor.Add(logs);
        //
        //     convertor.Start();
        //
        //     convertor.Update(0.3f);
        //     convertor.Update(0.3f);
        //     convertor.Update(0.3f);
        //     convertor.Update(0.3f);
        //     convertor.Update(0.2f);
        //
        //     Assert.AreEqual(convertor.ResourceCount, 10);
        //     Assert.AreEqual(convertor.ProductCount, 100);
        // }
        //
        //
        // [Test]
        // public void Start_StartProcessing_IsActiveStateTrue()
        // {
        //     var convertor = _defaultConverter;
        //     convertor.Start();
        //     Assert.IsTrue(convertor.IsActive);
        // }
        //
        //
        // [Test]
        // public void Stop_StopProcessing_IsActiveStateFalse()
        // {
        //     var convertor = _defaultConverter;
        //     convertor.Stop();
        //     Assert.IsFalse(convertor.IsActive);
        // }
        //
        //
        // [TestCase(5, 5, 5, 5, 5.5f)]
        // [TestCase(0, 0, 0, 0, 0f)]
        // public void Converter_Initialization_ShouldBeNotNull(int converterCapacity,
        //                                                      int productStorageCapacity,
        //                                                      int resourceStorageCapacity,
        //                                                      int productPerResource,
        //                                                      float timePerLoad)
        // {
        //     var convertor = new Convertor<StubLog, StubPlank>(converterCapacity,
        //                                                       productStorageCapacity,
        //                                                       resourceStorageCapacity,
        //                                                       productPerResource,
        //                                                       timePerLoad);
        //
        //     Assert.IsNotNull(convertor);
        // }
        //
        //
        // [TestCase(-5, 5, 5, 5, 5.5f)]
        // [TestCase(5, -5, 5, 5, 5.5f)]
        // [TestCase(5, 5, -5, 5, 5.5f)]
        // [TestCase(5, 5, 5, -5, 5.5f)]
        // [TestCase(5, 5, 5, 5, -5.5f)]
        // public void Convertor_InitializationWithNegativeParameters_ShouldThrowException(int converterCapacity,
        //     int productStorageCapacity,
        //     int resourceStorageCapacity,
        //     int productPerResource,
        //     float timePerLoad)
        // {
        //     Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Convertor<StubLog, StubPlank>(
        //                                                          converterCapacity,
        //                                                          productStorageCapacity,
        //                                                          resourceStorageCapacity,
        //                                                          productPerResource, timePerLoad));
        // }
        //
        //
        // [Test]
        // public void Add_AddResourcesWithNulls_ShouldBeAdded()
        // {
        //     var convertor = _defaultConverter;
        //
        //     var logs = new StubLog[]
        //     {
        //         new(),
        //         null,
        //         new(),
        //     };
        //
        //     var added = convertor.Add(logs);
        //
        //     Assert.AreEqual(added, 2);
        // }
        //
        //
        // [Test]
        // public void Add_AddResourcesWithDoubles_ShouldBeAdded()
        // {
        //     var convertor = _defaultConverter;
        //
        //     var log = new StubLog();
        //
        //     var logs = new StubLog[]
        //     {
        //         new(),
        //         log,
        //         log
        //     };
        //
        //     var added = convertor.Add(logs);
        //
        //     Assert.AreEqual(added, 2);
        // }
        //
        //
        // [Test]
        // public void Add_AddNull_ShouldBeAdded()
        // {
        //     var convertor = _defaultConverter;
        //
        //     Assert.Catch<ArgumentNullException>(() => _ = convertor.Add(null));
        // }
        //
        //
        // [Test]
        // public void Add_AddEmpty_ShouldBeAdded()
        // {
        //     var convertor = _defaultConverter;
        //
        //     var logs = new StubLog[] { };
        //
        //     var added = convertor.Add(logs);
        //
        //     Assert.AreEqual(added, 0);
        // }
        //
        //
        // private StubLog[] CreateLogs(int count)
        // {
        //     var logs = new StubLog[count];
        //
        //     for (var i = 0; i < count; i++)
        //         logs[i] = new StubLog();
        //
        //     return logs;
        // }
    }
}