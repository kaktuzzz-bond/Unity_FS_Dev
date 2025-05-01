using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public interface IEntityRaycastSensor
    {
        IEnumerable<T> Scan<T>(Vector2 direction) where T : class;

        IEnumerable<Collider2D> Scan(Vector2 direction);
    }
}