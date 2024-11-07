using Modules.Spaceships.Components;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.Modules.Spaceship.Tests.ComponentTests
{
    [TestFixture]
    public class MoveComponentTests
    {
        [Test]
        public void MoveComponent_Initialization_ShouldNotBeNull()
        {
            Assert.IsNotNull(new MoveComponent(1));
        }

        [Test]
        public void Move_ChangeTargetPosition_TargetPositionShouldBeChanged()
        {
            var moveComponent = new MoveComponent(1);

            var target = new GameObject().transform;
            var velocity = new Vector2(1, 1);
            const int deltaTime = 1;

            moveComponent.Move(target, velocity, deltaTime);

            var expectedPosition = new Vector2(1, 1);

            Assert.That(moveComponent.CurrentPosition, Is.EqualTo(expectedPosition));
        }
    }
}