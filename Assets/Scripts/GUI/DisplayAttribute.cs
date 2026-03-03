using System;
using PlayerScripts;
using TMPro;
using UnityEngine;

namespace GUI
{
    public abstract class DisplayAttribute : MonoBehaviour
    {
        protected Player player;
        [SerializeField] protected string attributeName;
        protected float displayPrimaryValue;
        protected float displaySecondaryValue;
        protected TMP_Text tmpText;

        protected virtual void Awake()
        {
            // Initialize components
            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
            tmpText = GetComponent<TMP_Text>();
        }

        protected virtual void Start()
        {
            // Subscribe to events
            SubscribeToAttributeEvent(); // This method NEEDS to run in Start to ensure it always occurs after the player has subscribed to the attribute change events. This way, the methods that change the GUI always run after the player has changed their attributes.
            
            // Initialize GUI
            DisplayValues();
        }

        public virtual void DisplayValues()
        {
            UpdateValues();
            
            tmpText.text = $"{attributeName}: {displayPrimaryValue:0.00}/x{displaySecondaryValue:0.00}";
        }

        protected abstract void SubscribeToAttributeEvent();
        protected abstract void UpdateValues();
    }
}