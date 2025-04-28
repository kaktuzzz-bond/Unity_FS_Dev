using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.Components.Movement.Move
{
    public interface IMovable
    {
        void MoveHorizontal(Vector3 direction);
        
        void Move(Vector3 direction);
    }
}