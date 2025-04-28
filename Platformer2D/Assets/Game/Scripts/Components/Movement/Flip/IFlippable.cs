using UnityEngine;

namespace Game.Scripts.Components.Movement.Flip
{
    public interface IFlippable
    {
        Vector3 GetScale { get; }

        void LookTowards(Vector3 direction);
    }
}