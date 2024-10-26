using System;
using UnityEngine;

namespace Modules.PlayerInput
{
    public class InputAdapter : MonoBehaviour
    {
        public event Action OnLeftPressed;
        public event Action OnRightPressed;
        public event Action OnFirePressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnFirePressed?.Invoke();

            if (Input.GetKey(KeyCode.LeftArrow))
                OnLeftPressed?.Invoke();

            else if (Input.GetKey(KeyCode.RightArrow))
                OnRightPressed?.Invoke();
        }
    }
}