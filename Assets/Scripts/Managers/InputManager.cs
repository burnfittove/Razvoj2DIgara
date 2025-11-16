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
            GameEventManager.Instance.InputEvents.MovePressed(context.ReadValue<Vector2>());
        }

        public void FirePressed(InputAction.CallbackContext context)
        {
            GameEventManager.Instance.InputEvents.FirePressed(context.ReadValue<float>());
        }

        public void MouseMoved(InputAction.CallbackContext context)
        {
            GameEventManager.Instance.InputEvents.MouseMoved(context.ReadValue<Vector2>());
        }
    }
}
