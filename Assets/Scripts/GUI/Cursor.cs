using UnityEngine;
using UnityEngine.InputSystem;

namespace GUI
{
    public class Cursor : MonoBehaviour
    { 
        private RectTransform rectTransform;

        private void Start()
        {
            TryGetComponent(out rectTransform);
        }

        // Update is called once per frame
        void Update()
        {
            rectTransform.position = Mouse.current.position.ReadValue();
        }
    }
}
