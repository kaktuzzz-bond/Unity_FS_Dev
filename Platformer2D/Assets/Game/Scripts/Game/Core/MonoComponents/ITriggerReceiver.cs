using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.MonoComponents
{
    public interface ITriggerReceiver
    {
        event Action<Collider2D> OnTriggerEnter;
        event Action<Collider2D> OnTriggerExit;
    }
}