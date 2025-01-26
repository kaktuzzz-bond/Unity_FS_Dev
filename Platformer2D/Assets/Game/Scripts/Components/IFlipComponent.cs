using UnityEngine;

namespace Game.Scripts.Components
{
    public interface IFlipComponent
    {
        void LookTowards(Vector3 direction);
    }
}