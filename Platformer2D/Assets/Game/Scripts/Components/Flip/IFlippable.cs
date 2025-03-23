using UnityEngine;

namespace Game.Scripts.Components.Flip
{
    public interface IFlippable
    {
        void LookTowards(Vector3 direction);
    }
}