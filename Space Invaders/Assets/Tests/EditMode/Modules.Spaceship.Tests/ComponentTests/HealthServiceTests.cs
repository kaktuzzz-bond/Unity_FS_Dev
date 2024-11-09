using System;
using Modules.Spaceships.Health;
using NUnit.Framework;

namespace Tests.EditMode.Modules.Spaceship.Tests.ComponentTests
{
    [TestFixture]
    public class HealthServiceTests
    {
        [TestCase(5, 6, 5)]
        [TestCase(5, -1, 5)]
        [TestCase(5, 3, 3)]
        public void Restore_FullRestoreHealth_CurrentHealthIsEqualToMaxHealth(int maxHealth, int restoreHealth,
            int expectedHealth)
        {
            var healthComponent = new HealthService(maxHealth, 1);

            healthComponent.ResetHealth(restoreHealth);

            Assert.That(healthComponent.CurrentHealth, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void HealthComponent_Initialization_ShouldBeNotNull()
        {
            var healthComponent = new HealthService(5, 1);

            Assert.That(healthComponent, Is.Not.Null, "HealthComponent should not be null");
        }

        [TestCase(5, 2, 2)]
        [TestCase(2, 5, 2)]
        [TestCase(2, -5, 2)]
        public void HealthComponent_ConstructorInitialization_HealthValueShouldBeBetweenZeroAndMaxValue(int maxHealth,
            int startHealth, int expectedHealth)
        {
            var healthComponent = new HealthService(maxHealth, startHealth);

            Assert.That(healthComponent.CurrentHealth, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void HealthComponent_InitializeWithNegativeMaxHealth_ThrowOutOfRangeException()
        {
            Assert.That(() => new HealthService(-5, 1),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(3, 1, 2)]
        [TestCase(3, 5, 0)]
        public void HealthComponent_ReceiveDamage_CurrentHealthShouldBeDecreased(int startHealth, int receivedDamage,
            int expectedHealth)
        {
            var healthComponent = new HealthService(5, startHealth);

            healthComponent.TakeDamage(receivedDamage);

            Assert.That(healthComponent.CurrentHealth, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void HealthComponent_ReceiveFatalDamage_OnDiedEventShouldBeInvoked()
        {
            var healthComponent = new HealthService(5, 1);

            var count = 0;

            healthComponent.OnHealthEmpty += () => count++;

            var expectedResult = 1;

            healthComponent.TakeDamage(2);

            Assert.That(count, Is.EqualTo(expectedResult));
        }
    }
}