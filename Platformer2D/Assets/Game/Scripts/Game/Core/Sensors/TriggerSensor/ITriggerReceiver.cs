using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Sensors.TriggerSensor
{
    public interface ITriggerReceiver
    {
        event Action<Collider2D> OnTriggerEnter;
        event Action<Collider2D> OnTriggerExit;
    }
}