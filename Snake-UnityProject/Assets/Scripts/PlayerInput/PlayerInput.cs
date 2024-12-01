using Modules;
using UnityEngine;

namespace SampleGame
{
    public sealed class PlayerInput : IPlayerInput
    {
        private readonly PlayerInputMap _inputMap;

        public PlayerInput(PlayerInputMap inputMap)
        {
            _inputMap = inputMap;
        }
        
    
        public SnakeDirection GetDirection()
        {
            
            var direction = SnakeDirection.NONE;

            if (Input.GetKey(_inputMap.MoveUp)) direction = SnakeDirection.UP;
            else if (Input.GetKey(_inputMap.MoveDown)) direction = SnakeDirection.DOWN;
            else if (Input.GetKey(_inputMap.MoveLeft)) direction = SnakeDirection.LEFT;
            else if (Input.GetKey(_inputMap.MoveRight)) direction = SnakeDirection.RIGHT;

            return direction;
        }
    }
}