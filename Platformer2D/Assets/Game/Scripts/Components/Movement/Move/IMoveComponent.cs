using System;
using UnityEngine;

namespace Game.Scripts.Components.Movement.Move
{
    public interface IMoveComponent: IMovable
    {
        Vector2 BodyDirection { get; }
        void AddCondition(Func<bool> condition);
    }
}