using System;
using Events;
using Item.ActiveItem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class DisplayActiveItem : MonoBehaviour
    {
        private ActiveItem activeItem;
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private Image image;
        [SerializeField] private Slider slider;

        private void Awake()
        {
            GameEventManager.Instance.itemEvents.OnActiveItemAcquired += UpdateUI;
        }

        private void UpdateUI(GameObject obj)
        {
            // Get the active item component
            obj.TryGetComponent(out activeItem);
            // image = obj.GetComponent<SpriteRenderer>().sprite;
            // Set the name of the item
            tmpText.text = activeItem.ItemInformation.itemName;
            // Set the charge bar
            slider.maxValue = activeItem.ItemInformation.maxCharge;
            slider.value = activeItem.currentCharge;
        }
    }
}
