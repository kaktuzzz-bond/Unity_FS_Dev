using Modules.Spaceships.Weapon;
using NUnit.Framework;

namespace Tests.EditMode.Modules.Spaceship.Tests.ComponentTests
{
    public class WeaponServiceTests
    {
        [Test]
        public void WeaponComponent_Initialization_NotNull()
        {
            var weaponComponent = new WeaponService();
            
            Assert.IsNotNull(weaponComponent);
        }
    }
}