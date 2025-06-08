using System;
using UnityEngine;

namespace Game.Entities
{
    public interface ITriggerReceiver
    {
        event Action<Collider2D> OnTriggerEnter;
        event Action<Collider2D> OnTriggerExit;
    }
}