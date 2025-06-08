using System;
using UnityEngine;

namespace Game.Entities
{
    public interface IForceComponent : IPushable
    {
        event Action OnForceAdded;
        Vector2 Position { get; }
    }
}