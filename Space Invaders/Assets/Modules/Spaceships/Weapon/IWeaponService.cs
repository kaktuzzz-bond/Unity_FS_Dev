using UnityEngine;

namespace Modules.Spaceships.Weapon
{
    public interface IWeaponService 
    {
        void Attack(Vector2 direction);
    }
}