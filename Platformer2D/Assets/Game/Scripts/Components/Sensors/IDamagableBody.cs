using System;
using Game.Scripts.Components.Health;

namespace Game.Scripts.Components.Sensors
{
    public interface IDamagableBody: IDamagable
    {
        event Action<int> OnDamageTaken;
    }
}