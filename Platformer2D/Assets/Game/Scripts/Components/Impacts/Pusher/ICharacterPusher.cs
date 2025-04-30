using Game.Scripts.Components.Conditions;
using Game.Scripts.Components.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Components.Impacts.Pusher
{
    public interface ICharacterPusher: IConditionable
    {
        void Push(IPushableBody pushable, Vector2 direction);
    }
}