using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    public interface IForceComponent : IPushable
    {
        event Action OnForceAdded;
        Vector2 Position { get; }
    }
}