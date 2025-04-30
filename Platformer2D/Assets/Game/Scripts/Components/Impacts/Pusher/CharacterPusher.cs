using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Impacts.Pushable;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public class CharacterPusher : CompositeCondition, IInitializable, ICharacterPusher
    {
        private readonly IPusher _pusher;
        private readonly ICooldownTimer _timer;

        public CharacterPusher(IPusher pusher, ICooldownTimer timer)
        {
            _pusher = pusher;
            _timer = timer;
        }

        public void Initialize()
        {
            AddCondition(() => !_timer.IsInProgress);
        }

        public void Push(IPushableBody pushable, Vector2 direction)
        {
            if (!IsValid) return;
            
            _pusher.Push(pushable, direction);
            
            _timer.Launch();
        }
    }
}