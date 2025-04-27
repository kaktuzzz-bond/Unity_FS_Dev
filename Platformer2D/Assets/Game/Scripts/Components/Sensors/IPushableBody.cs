using System;
using Game.Scripts.Components.Impacts;
using UnityEngine;

namespace Game.Scripts.Components.Sensors
{
    public interface IPushableBody : IPushable
    {
        event Action<Vector3> OnImpacted;
    }
}