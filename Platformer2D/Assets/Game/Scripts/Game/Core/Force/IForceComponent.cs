using System;
using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    public interface IForceComponent
    {
        event Action OnForceAdded;
        Vector2 Position { get; }

        void AddForce(Vector2 force);

        void AddForce(Vector2 force, Vector2 otherPosition);
    }
}