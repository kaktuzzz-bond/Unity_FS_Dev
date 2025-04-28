using System;
using UnityEngine;

namespace Game.Scripts.PlayerInput
{
    public interface IPlayerInput
    {
        event Action<Vector3> OnMoved;
        event Action OnJumped;
        event Action OnPush;
        event Action OnToss;

        void EnableInput();

        void DisableInput();
    }
}