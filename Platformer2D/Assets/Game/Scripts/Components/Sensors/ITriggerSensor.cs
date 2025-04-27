using System;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public interface ITriggerSensor
    {
        event Action<Collider2D> OnTriggerEnter;
        event Action<Collider2D> OnTriggerExit;
    }
}