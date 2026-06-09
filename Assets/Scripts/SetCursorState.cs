using UnityEngine;

public class SetCursorState : MonoBehaviour
{
    [SerializeField] private bool _cursorVisible;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = _cursorVisible;
    }
}
