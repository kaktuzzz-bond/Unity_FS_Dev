using System.Collections.Generic;
using Game.Scripts.Game.Core.Impacts.Pushable;
using UnityEngine;

namespace Game.Scripts.Game.Core.Impacts.Pusher
{
    public interface ICharacterPusher
    {
        void Push();

        void Push(IPushableBody pushable, Vector2 direction);

        void Push(IEnumerable<IPushableBody> pushables, Vector2 direction);
    }
}