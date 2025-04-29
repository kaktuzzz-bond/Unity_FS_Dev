using System;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public interface ITriggerObserver
    {
        event Action<Collider2D> OnTriggerEnter;
        event Action<Collider2D> OnTriggerExit;
    }
}