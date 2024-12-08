using Input.InputMaps;
using Modules.Snake;

namespace Input
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

            if (UnityEngine.Input.GetKeyDown(_inputMap.MoveUp)) direction = SnakeDirection.UP;
            else if (UnityEngine.Input.GetKeyDown(_inputMap.MoveDown)) direction = SnakeDirection.DOWN;
            else if (UnityEngine.Input.GetKeyDown(_inputMap.MoveLeft)) direction = SnakeDirection.LEFT;
            else if (UnityEngine.Input.GetKeyDown(_inputMap.MoveRight)) direction = SnakeDirection.RIGHT;

            return direction;
        }
    }
}