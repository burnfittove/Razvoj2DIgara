using PlayerScripts;
using TMPro;
using UnityEngine;

namespace GUI
{
    /// <summary>
    /// Classes that inherit this scripts must update attributeValue and multiplierValue (if used) in Update()
    /// </summary>
    public class DisplayAttribute : DisplayValueWithTMPText
    {
        protected Player player;
        public bool displayMultiplier;
        protected float multiplierValue;

        protected override void Awake()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
            tmpText = GetComponent<TMP_Text>();
        }

        protected void LateUpdate()
        {
            UpdateText();
        }

        protected override void UpdateText()
        {
            tmpText.text = $"{label}: {value:0.00}{(displayMultiplier ? $"/x{multiplierValue:0.00}" : "")}";
        }
    }
}
