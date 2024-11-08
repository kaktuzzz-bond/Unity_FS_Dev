using System;
using Modules.Spaceships.Health;
using Modules.Spaceships.Movement;
using Modules.Spaceships.Weapon;
using NUnit.Framework;
using Tests.EditMode.Modules.Spaceship.Tests.ComponentTests;
using UnityEngine;

namespace Tests.EditMode.Modules.Spaceship.Tests
{
    public class SpaceshipTests
    {
        private readonly HealthServiceTests _healthServiceTests = new HealthServiceTests();

        [Test]
        public void Spaceship_Initialization_ShouldBeNotNull()
        {
            //var bulletSpawner = new GameObject().AddComponent<BulletSpawner>();

            var healthComponent = new HealthService(5, 1);
            
            var rb = new GameObject().AddComponent<Rigidbody2D>();
            var moveComponent = new Rigidbody2DMover(rb,5);
            
             var weaponComponent = new WeaponService();


            //var spaceshipBuilder = new SpaceshipBuilder();


            //Movable
            //Attackable
            //Settings : sprite
        }
    }
}