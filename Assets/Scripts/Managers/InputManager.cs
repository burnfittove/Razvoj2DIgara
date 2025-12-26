using Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : MonoBehaviour
    {
        public void MovePressed(InputAction.CallbackContext context)
        {
            GameEventManager.Instance.inputEvents.MovePressed(context);
        }

        public void FirePressed(InputAction.CallbackContext context)
        {
            GameEventManager.Instance.inputEvents.FirePressed(context);
        }

        public void MouseMoved(InputAction.CallbackContext context)
        {
            GameEventManager.Instance.inputEvents.MouseMoved(context);
        }
    }
}
