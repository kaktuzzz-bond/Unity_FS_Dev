using Modules.Spaceships.Components;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode.Modules.Spaceship.Tests.ComponentTests
{
    [TestFixture]
    public class MoveRigidbody2DComponentTests
    {
        [Test]
        public void MoveRigidbody2DComponent_Initialization_IsNotNull()
        {
            var rb = new Rigidbody2D();
            var moveComponent = new MoveRigidbody2DComponent(rb, 1);
            
            Assert.IsNotNull(moveComponent);
        }
        
        [Test]
        public void Move_ChangeTargetPosition_TargetPositionShouldBeChanged()
        {
            var rb = new GameObject().AddComponent<Rigidbody2D>();
            rb.position = Vector2.zero;
            var moveComponent = new MoveRigidbody2DComponent(rb,1);
            
            var velocity = new Vector2(1, 1);
            const int deltaTime = 1;

            moveComponent.Move(velocity, deltaTime);

            var expectedPosition = new Vector2(1, 1);

            Assert.That(moveComponent.TargetPosition, Is.EqualTo(expectedPosition));
        }
    }
}