using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public void MovePressed(InputAction.CallbackContext context)
    {
        GameEventManager.instance.inputEvents.MovePressed(context.ReadValue<Vector2>());
    }

    public void FirePressed(InputAction.CallbackContext context)
    {
        GameEventManager.instance.inputEvents.FirePressed(context.ReadValue<float>());
    }

    public void MouseMoved(InputAction.CallbackContext context)
    {
        GameEventManager.instance.inputEvents.MouseMoved(context.ReadValue<Vector2>());
    }
}
