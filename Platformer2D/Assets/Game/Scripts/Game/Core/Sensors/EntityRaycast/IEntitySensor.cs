using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Game.Core.Sensors.EntityRaycast
{
    public interface IEntitySensor
    {
        bool Push(Vector2 scanDirection);
    }
}