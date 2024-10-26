using UnityEngine;

namespace Gameplay.Weapon
{
    public interface IWeapon
    {
        void Fire(Vector2 position, Vector2 velocity);
    }
}