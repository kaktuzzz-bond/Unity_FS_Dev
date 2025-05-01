using System;
using UnityEngine;

namespace Game.Scripts.Components.Sensors.TriggerObserver
{
    [Serializable]
    public class TriggerObserverData
    {
        [field: SerializeField]
        public TriggerObserver TriggerObserver { get; private set; }
    }
}