using System;
using UnityEngine;

namespace Game.Entities
{
    public interface IPushable
    {
        event Action OnForceAdded;

        void AddForce(Vector2 force);
    }
}