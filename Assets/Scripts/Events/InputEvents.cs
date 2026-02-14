using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Events
{
    public class InputEvents
    {
        public event Action<InputAction.CallbackContext> OnMovePressed;
        public void MovePressed(InputAction.CallbackContext direction)
        {
            OnMovePressed?.Invoke(direction);
        }

        public event Action<InputAction.CallbackContext> OnFirePressed;
        public void FirePressed(InputAction.CallbackContext isPressed)
        {
            OnFirePressed?.Invoke(isPressed);
        }

        public event Action<InputAction.CallbackContext> OnMouseMoved;
        public void MouseMoved(InputAction.CallbackContext position)
        {
            OnMouseMoved?.Invoke(position);
        }

        public event Action<InputAction.CallbackContext> OnActiveItemUsed;
        public void ActiveItemUsed(InputAction.CallbackContext itemUsed)
        {
            OnActiveItemUsed?.Invoke(itemUsed);
        }
        
        public event Action<InputAction.CallbackContext> OnQuitGame;
        public void QuitGame(InputAction.CallbackContext isPressed)
        {
            OnQuitGame?.Invoke(isPressed);
        }
    }
}
