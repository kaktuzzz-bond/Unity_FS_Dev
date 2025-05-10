using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Sensors.TriggerObserver
{
    [Serializable]
    public class TriggerObserverData
    {
        [field: SerializeField]
        public TriggerObserver TriggerObserver { get; private set; }
    }
}