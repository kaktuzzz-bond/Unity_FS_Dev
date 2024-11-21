using System;
using Converter;
using NUnit.Framework;
using Tests.EditMode.Stubs;


namespace Tests.EditMode
{
    [TestFixture]
    public class ConvertorTests
    {
        private Convertor<StubLog, StubPlank> _defaultConvertor;


        [SetUp]
        public void Setup()
        {
            _defaultConvertor = new Convertor<StubLog, StubPlank>(1, 1, 1, 1, 1f);
        }


        [Test]
        public void Start_StartProcessing_IsActiveStateTrue()
        {
            var convertor = _defaultConvertor;
            convertor.Start();
            Assert.IsTrue(convertor.IsActive);
        }


        [Test]
        public void Stop_StopProcessing_IsActiveStateFalse()
        {
            var convertor = _defaultConvertor;
            convertor.Stop();
            Assert.IsFalse(convertor.IsActive);
        }


        [Test]
        [TestCase(-1, 1, 1, 1, 1f)]
        [TestCase(1, -1, 1, 1, 1f)]
        [TestCase(1, 1, -1, 1, 1f)]
        [TestCase(1, 1, 1, -1, 1f)]
        [TestCase(1, 1, 1, 1, -1f)]
        public void Constructor_InitializeWithNgativeParameters_ThrowsException(int resourceStorageCapacity,
            int productStorageCapacity,
            int loadAmount,
            int unloadAmount,
            float processingTime)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Convertor<StubLog, StubPlank>(
                                                                 resourceStorageCapacity,
                                                                 productStorageCapacity,
                                                                 loadAmount,
                                                                 unloadAmount,
                                                                 processingTime));
        }


        [Test]
        public void Constructor_InitializeWithValidParameters_ExpectNotNull()
        {
            Assert.IsNotNull(_defaultConvertor);
        }
    }
}