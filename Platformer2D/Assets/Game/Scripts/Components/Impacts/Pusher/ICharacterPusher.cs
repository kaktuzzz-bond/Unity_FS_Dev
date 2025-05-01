using System.Collections.Generic;
using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public interface ICharacterPusher : IConditionable
    {
        void Push();

        void Push(IPushableBody pushable, Vector2 direction);

        void Push(IEnumerable<IPushableBody> pushables, Vector2 direction);
    }
}