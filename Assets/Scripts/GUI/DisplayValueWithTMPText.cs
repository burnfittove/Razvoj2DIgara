using TMPro;
using UnityEngine;

namespace GUI
{
    public abstract class DisplayValueWithTMPText : MonoBehaviour
    {
        protected TMP_Text tmpText;
        public string label;
        protected float value;
        
        protected virtual void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
        }

        protected virtual void UpdateText()
        {
            tmpText.text = $"{label}: {value}";
        }
    }
}