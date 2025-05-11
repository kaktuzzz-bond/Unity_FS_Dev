using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    public interface IForceComponent
    {
        void AddForce(Vector2 force);
    }
}