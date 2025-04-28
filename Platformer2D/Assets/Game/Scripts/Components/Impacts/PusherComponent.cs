using Game.Scripts.Player.Settings;
using UnityEngine;

namespace Game.Scripts.Components.Impacts
{
    public class PusherComponent : IPusher
    {
        private readonly PushSettings _settings;
        

        public PusherComponent(PushSettings settings)
        {
            _settings = settings;
        }

        public void Push(IPushable pushable)
        {
            Push(pushable, _settings.DefaultDirection);
        }

        public void Push(IPushable pushable, Vector3 direction)
        {
            pushable.TakePush(_settings.GetForce(direction));
        }
    }
}