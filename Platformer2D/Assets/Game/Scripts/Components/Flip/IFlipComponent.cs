using UnityEngine;

namespace Game.Scripts.Components.Flip
{
    public interface IFlipComponent
    {
        void LookTowards(Vector3 direction);
    }
}