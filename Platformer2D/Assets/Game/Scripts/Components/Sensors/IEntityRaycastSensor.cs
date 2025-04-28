using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public interface IEntityRaycastSensor
    {
        IEnumerable<Collider2D> Scan(Vector2 direction);
    }
}