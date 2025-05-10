using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    public interface IForceComponent
    {
        void AddForce(Rigidbody2D rigidbody, Vector2 force);
    }
}