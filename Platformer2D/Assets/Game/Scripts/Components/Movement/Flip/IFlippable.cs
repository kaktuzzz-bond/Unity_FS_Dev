using UnityEngine;

namespace Game.Scripts.Components.Movement.Flip
{
    public interface IFlippable
    {
        void LookTowards(Vector3 direction);
    }
}