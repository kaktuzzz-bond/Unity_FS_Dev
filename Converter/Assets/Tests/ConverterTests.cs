using System;
using Homework;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public sealed class ConverterTests
    {
        private Converter<WoodenLog, WoodenPlank> _converter;


        [SetUp]
        public void Setup()
        {
            _converter = new Converter<WoodenLog, WoodenPlank>();
        }


        [TestCase(0, true)]
        [TestCase(3, true)]
        public void SetLoadAreaCapacity_WithValidRangeValues_ShouldBeValidAndCorrect(int value, bool expected)
        {
            var converterResult = _converter.SetCapacity(value);
            var loadResult = _converter.SetLoadAreaCapacity(value);
            var unloadResult = _converter.SetUnloadAreaCapacity(value);

            Assert.IsTrue(loadResult == expected, $"CONVERTER :: Expected: {expected}, Actual: {converterResult}");
            Assert.IsTrue(loadResult == expected, $"LOAD :: Expected: {expected}, Actual: {loadResult}");
            Assert.IsTrue(unloadResult == expected, $"UNLOAD :: Expected: {expected}, Actual: {unloadResult}");
        }


        [Test]
        public void SetCapacities_WithNegativeValue_ShouldThrowException()
        {
            var value = -3;
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter.SetLoadAreaCapacity(value));
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter.SetUnloadAreaCapacity(value));
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter.SetCapacity(value));
        }


        [TestCase(0.5f, true)]
        [TestCase(1f, true)]
        [TestCase(0f, true)]
        public void SetEfficiency_WithValidRange_PropertyValueShouldBeChanged(float value, bool expected)
        {
            var result = _converter.SetEfficiency(value);

            Assert.IsTrue(result == expected,
                          $"Efficiency :: Expected: {expected}, Actual: {result}");

            Assert.IsTrue(Mathf.Approximately(value, _converter.Efficiency),
                          $"Efficiency :: In: {value}, Actual: {_converter.Efficiency} ");
        }


        [TestCase(-1f)]
        [TestCase(5f)]
        public void SetEfficiency_WithOutOfRangeValue_ShouldThrowException(float value)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => _converter.SetEfficiency(value));
        }


        [TestCase(false, false)]
        [TestCase(true, true)]
        public void IsActive_ChangeActivityState_PropertyValueShouldBeChanged(bool isActive, bool expected)
        {
            _converter.Activate(isActive);

            var result = _converter.IsActive;

            Assert.IsTrue(result == expected,
                          $"Efficiency :: Expected: {expected}, Actual: {result}");
        }


        [Test]
        public void Constructor_Initialization_NotNull()
        {
            Assert.IsNotNull(_converter);
        }
    }
}