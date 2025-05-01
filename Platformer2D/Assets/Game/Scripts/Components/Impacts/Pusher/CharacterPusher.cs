using System.Collections.Generic;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Cooldown;
using Game.Scripts.Components.Impacts.Pushable;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public class CharacterPusher : CompositeCondition, ICharacterPusher, IInitializable
    {
        private readonly IPusher _pusher;
        [ShowInInspector, ReadOnly]
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

        public void Push()
        {
            if (!IsValid) return;

            _timer.Launch();
        }

        public void Push(IPushableBody pushable, Vector2 direction)
        {
            if (!IsValid) return;
            
            _pusher.Push(pushable, direction);

            _timer.Launch();
        }
        
        public void Push(IEnumerable<IPushableBody> pushables, Vector2 direction)
        {
            if (!IsValid) return;
            
            foreach (var body in pushables)
            {
                _pusher.Push(body, direction);
            }

            _timer.Launch();
        }
    }
}