using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Sensors.TriggerObserver
{
    public interface ITriggerObserver
    {
        event Action<Collider2D> OnTriggerEnter;
        event Action<Collider2D> OnTriggerExit;
    }
}