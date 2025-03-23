using System;
using Game.Scripts.Components.Health;

namespace Game.Scripts.Components.Sensors
{
    public interface ITriggerProxy
    {
        event Action<IDamagable> OnTriggered;
    }
}