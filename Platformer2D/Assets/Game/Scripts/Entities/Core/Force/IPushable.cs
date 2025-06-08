using UnityEngine;

namespace Game.Entities
{
    public interface IPushable
    {
        void AddForce(Vector2 force);

        void AddForce(Vector2 force, Vector2 otherPosition);
    }
}