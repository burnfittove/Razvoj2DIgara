using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputEvents
{
    public event Action<Vector2> OnMovePressed;
    public void MovePressed(Vector2 direction)
    {
        OnMovePressed?.Invoke(direction);
    }

    public event Action<float> OnFirePressed;
    public void FirePressed(float isPressed)
    {
        OnFirePressed?.Invoke(isPressed);
    }
}
