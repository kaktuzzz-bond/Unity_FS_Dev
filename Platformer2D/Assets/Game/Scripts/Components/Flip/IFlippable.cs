using UnityEngine;

namespace Game.Scripts.Components.Flip
{
    public interface IFlippable
    {
        public Vector3 GetDirection { get; }

        public void LookTowards(Vector3 direction);
        public void LookTowardsX(float direction);
        
    }
}