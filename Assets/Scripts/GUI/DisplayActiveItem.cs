using System;
using Events;
using Item.ActiveItem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GUI
{
    public class DisplayActiveItem : MonoBehaviour
    {
        private ActiveItem activeItem;
        private int maxCharge;
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private Image image;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            GameEventManager.Instance.itemEvents.OnActiveItemAcquired += UpdateUI;
            // GameEventManager.Instance.inputEvents.OnActiveItemUsed += ActiveItemUsed;
            
            tmpText.text = "";
            image.enabled = false;
            slider.transform.parent.gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            // If the player doesn't have an active item, return
            if (!activeItem) return;
            
            // Set the charge bar
            slider.value = activeItem.currentCharge;
        }

        private void UpdateUI(GameObject obj)
        {
            if (obj == null) return;
            
            // Enable components
            image.enabled = true;
            slider.transform.parent.gameObject.SetActive(true);
            
            // Get the active item component
            obj.TryGetComponent(out activeItem);
            
            // Set the color of the square
            image.color = obj.GetComponent<SpriteRenderer>().color;
            
            // Set the name of the item
            tmpText.text = activeItem.ItemInformation.itemName;
            
            // Set the charge bar
            slider.maxValue = activeItem.ItemInformation.maxCharge;
            slider.value = activeItem.currentCharge;
        }
        //
        // private void UpdateSlider(int value)
        // {
        //     if (activeItem.currentCharge < activeItem.ItemInformation.maxCharge) slider.value = value;
        // }
        //
        // private void ActiveItemUsed(InputAction.CallbackContext context)
        // {
        //     if (!context.performed) return;
        //     if (!activeItem) return;
        //     UpdateSlider(activeItem.currentCharge);
        // }
    }
}
