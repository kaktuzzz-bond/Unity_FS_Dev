using UnityEngine;

namespace Game.Scripts.Game.Core.Force
{
    public interface IPushable
    {
        void AddForce(Vector2 force);

        void AddForce(Vector2 force, Vector2 otherPosition);
    }
}