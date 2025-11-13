using Events;
using Unity.VisualScripting;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [Header("Components")]
    private RectTransform rt;
    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        GameEventManager.Instance.inputEvents.OnMouseMoved += MoveCursor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveCursor(Vector2 position)
    {
        rt.position = position;
    }
    
    void OnDisable()
    {
        GameEventManager.Instance.inputEvents.OnMouseMoved -= MoveCursor;
    }
}
