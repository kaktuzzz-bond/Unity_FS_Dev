using UnityEngine;

namespace Gameplay.Bullets
{
    public interface IWeapon
    {
        void Fire(Vector2 position, Vector2 velocity);
    }
}