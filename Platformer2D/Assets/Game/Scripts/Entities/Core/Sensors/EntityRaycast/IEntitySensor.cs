using UnityEngine;

namespace Game.Entities
{
    public interface IEntitySensor
    {
        bool Push(Vector2 scanDirection);
    }
}