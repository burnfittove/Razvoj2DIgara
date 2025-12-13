using PlayerScripts;
using TMPro;
using UnityEngine;

namespace GUI
{
    /// <summary>
    /// Classes that inherit this scripts must update attributeValue and multiplierValue (if used) in Update()
    /// </summary>
    public class DisplayAttribute : MonoBehaviour
    {
        protected TMP_Text tmpText;
        protected Player player;
        public string label;
        protected float attributeValue;
        public bool displayMultiplier;
        protected float multiplierValue;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
            tmpText = GetComponent<TMP_Text>();
        }

        protected void LateUpdate()
        {
            UpdateText(attributeValue, multiplierValue);
        }

        protected virtual void UpdateText(float attrVal, float multVal)
        {
            tmpText.text = $"{label}: {attrVal:0.00}{(displayMultiplier ? $"/x{multVal:0.00}" : "")}";
        }
    }
}
