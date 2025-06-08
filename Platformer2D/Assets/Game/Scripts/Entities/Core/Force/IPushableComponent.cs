using System;
using UnityEngine;

namespace Game.Entities
{
    public interface IPushableComponent
    {
        event Action OnForceAdded;

        Vector2 GetPosition { get; }

        void AddForce(Vector2 force, Vector2 otherPosition);
        
        void AddForce(Vector2 force);
    }
}