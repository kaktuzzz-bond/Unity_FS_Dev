using Modules.Spaceships.Movement;
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
            var rb = new GameObject().AddComponent<Rigidbody2D>();
            Assert.IsNotNull(new Rigidbody2DMover(rb, 1));
        }

        // [Test]
        // public void Move_ChangeTargetPosition_TargetPositionShouldBeChanged()
        // {
        //     var rb = new GameObject().AddComponent<Rigidbody2D>();
        //     var moveComponent = new Rigidbody2DMover(rb, 1);
        //
        //     var velocity = new Vector2(1, 1);
        //
        //     moveComponent.Move(velocity);
        //
        //     var expectedPosition = new Vector2(1, 1);
        //
        //     Assert.That(moveComponent.TargetPosition, Is.EqualTo(expectedPosition));
        // }
    }
}