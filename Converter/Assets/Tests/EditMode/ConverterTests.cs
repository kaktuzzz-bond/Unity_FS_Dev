using System;
using NUnit.Framework;
using Tests.Stubs;
using UnityEngine;

namespace Tests.EditMode
{
    public sealed class ConverterTests
    {
        [Test]
        [TestCase(2.5f)]
        [TestCase(1f)]
        [TestCase(0f)]
        public void SetDuration_WithValidValues_DurtionValueShouldBeSet(float value)
        {
            var converter = new Converter.Converter<StubLog, StubPlank>(5, 5, 5);

            var success = converter.SetDuration(value);

            Assert.IsTrue(success,
                          $" Set Efficiency :: Success: {success}");

            var duration = converter.Duration;

            Assert.IsTrue(Mathf.Approximately(value, duration),
                          $"Efficiency :: Set: {value}, Actual: {duration} ");
        }


        [Test]
        public void SetDuration_WithNegativeValue_ThrowException()
        {
            var duration = -2.5f;
            var converter = new Converter.Converter<StubLog, StubPlank>(5, 5, 5);
            Assert.Catch<ArgumentOutOfRangeException>(() => converter.SetDuration(duration));
        }


        [TestCase(0.5f)]
        [TestCase(1f)]
        [TestCase(0f)]
        public void SetEfficiency_WithValidRange_EfficiencyValueShouldBeSet(float value)
        {
            var converter = new Converter.Converter<StubLog, StubPlank>(5, 5, 5);

            var success = converter.SetEfficiency(value);

            Assert.IsTrue(success,
                          $" Set Efficiency :: Success: {success}");

            var efficiency = converter.Efficiency;

            Assert.IsTrue(Mathf.Approximately(value, efficiency),
                          $"Efficiency :: Set: {value}, Actual: {efficiency} ");
        }


        [TestCase(-1f)]
        [TestCase(5f)]
        public void SetEfficiency_WithOutOfRangeValue_ThrowException(float value)
        {
            var converter = new Converter.Converter<StubLog, StubPlank>(5, 5, 5);
            Assert.Catch<ArgumentOutOfRangeException>(() => converter.SetEfficiency(value));
        }


        [Test]
        public void Start_ActivateConverter_IsActiveStateShouldBeTrue()
        {
            var converter = new Converter.Converter<StubLog, StubPlank>(5, 5, 5);

            converter.Start();

            Assert.IsTrue(converter.IsActive, "The converter should be active");
        }


        [Test]
        public void Stop_DeactivateConverter_IsActiveStateShouldBeFalse()
        {
            var converter = new Converter.Converter<StubLog, StubPlank>(5, 5, 5);

            converter.Stop();

            Assert.IsFalse(converter.IsActive, "The converter should not be active");
        }


        [TestCase(5, 5, -1)]
        [TestCase(5, -1, 5)]
        [TestCase(-1, 5, 5)]
        public void Constructor_InitializeWithNegativeOrInvalidValues_ThrowException(int loadingAreaCapacity,
            int unloadingAreaCapacity,
            int ownCapacity)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => _ = new Converter.Converter<StubLog, StubPlank>(loadingAreaCapacity,
                                                                                                    unloadingAreaCapacity, ownCapacity));
        }


        [TestCase(0, 0, 0)]
        [TestCase(5, 5, 5)]
        public void Constructor_InitializeWithValidValues_NotNull(int loadingAreaCapacity,
                                                                  int unloadingAreaCapacity,
                                                                  int ownCapacity)
        {
            var converter = new Converter.Converter<StubLog, StubPlank>(loadingAreaCapacity, unloadingAreaCapacity, ownCapacity);
            Assert.IsNotNull(converter, "The converter should not be null.");
        }
    }
}