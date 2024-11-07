using System;
using Modules.Spaceships.Scripts.Components;
using NUnit.Framework;

namespace Tests.EditMode.Modules.Spaceship.Tests
{
    [TestFixture]
    public class HealthComponentTests
    {
        [TestCase(5, 6, 5)]
        [TestCase(5, -1, 5)]
        [TestCase(5, 3, 3)]
        public void Restore_FullRestoreHealth_CurrentHealthIsEqualToMaxHealth(int maxHealth, int restoreHealth,
            int expectedHealth)
        {
            var healthComponent = new HealthComponent(maxHealth, 1);

            healthComponent.Restore(restoreHealth);

            Assert.That(healthComponent.CurrentHealth, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void HealthComponent_Initialization_ShouldBeNotNull()
        {
            var healthComponent = new HealthComponent(5, 1);

            Assert.That(healthComponent, Is.Not.Null, "HealthComponent should not be null");
        }

        [TestCase(5, 2, 2)]
        [TestCase(2, 5, 2)]
        [TestCase(2, -5, 2)]
        public void HealthComponent_ConstructorInitialization_HealthValueShouldBeBetweenZeroAndMaxValue(int maxHealth,
            int startHealth, int expectedHealth)
        {
            var healthComponent = new HealthComponent(maxHealth, startHealth);

            Assert.That(healthComponent.CurrentHealth, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void HealthComponent_InitializeWithNegativeMaxHealth_ThrowOutOfRangeException()
        {
            Assert.That(() => new HealthComponent(-5, 1),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(3, 1, 2)]
        [TestCase(3, 5, 0)]
        public void HealthComponent_ReceiveDamage_CurrentHealthShouldBeDecreased(int startHealth, int receivedDamage,
            int expectedHealth)
        {
            var healthComponent = new HealthComponent(5, startHealth);

            healthComponent.ReceiveDamage(receivedDamage);

            Assert.That(healthComponent.CurrentHealth, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void HealthComponent_ReceiveFatalDamage_OnDiedEventShouldBeInvoked()
        {
            var healthComponent = new HealthComponent(5, 1);

            var count = 0;

            healthComponent.OnDied += () => count++;

            var expectedResult = 1;

            healthComponent.ReceiveDamage(2);

            Assert.That(count, Is.EqualTo(expectedResult));
        }
    }
}