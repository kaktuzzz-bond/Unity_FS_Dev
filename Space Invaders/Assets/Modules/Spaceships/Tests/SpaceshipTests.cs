using Modules.Spaceships.Scripts;
using Modules.Spaceships.Scripts.Components;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Pool;


namespace Modules.Spaceships.Tests
{
    
    public class SpaceshipTests
    {
        [Test]
        public void Spaceship_Initialization_ShouldBeNotNull()
        {

           var bulletSpawner = new GameObject().AddComponent<BulletSpawner>();
          
            var healthComponent = new HealthComponent(5, 1);
            var moveComponent = new MoveComponent(5);
            var attackComponent = new AttackComponent(bulletSpawner);
           
            
            var spaceship = new Spaceship();
            
            
           
            //Movable
            //Attackable
            //Settings : sprite
        }
    }
}