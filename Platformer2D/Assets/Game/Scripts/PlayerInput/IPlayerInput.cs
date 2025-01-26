using System;
using UnityEngine;

namespace Game.Scripts.PlayerInput
{
    public interface IPlayerInput
    {
        event Action<Vector3> OnMoved;
        event Action OnJumped;

        void EnableInput();

        void DisableInput();
    }
}