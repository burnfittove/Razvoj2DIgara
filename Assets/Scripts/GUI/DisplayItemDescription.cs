using Events;
using TMPro;
using UnityEngine;

namespace GUI
{
    public class DisplayItemDescription : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text itemName;
        [SerializeField]
        private TMP_Text itemDescription;

        private void Awake()
        {
            gameObject.SetActive(false);
            GameEventManager.Instance.itemEvents.OnNearbyItemDetected += UpdateItemDescriptionUI;
            GameEventManager.Instance.itemEvents.OnNearbyItemLost += () => gameObject.SetActive(false);
        }

        private void UpdateItemDescriptionUI(Item.Item item)
        {
            gameObject.SetActive(true);
            itemName.text = $"{item.ItemInformation.itemName} | {item.ItemInformation.itemQuality}";
            itemDescription.text = $"{(item.isBuyable ? $"Price: ${item.ItemInformation.price}/{item.ItemInformation.demonPrice} max health\n" : "")}{item.ItemInformation.itemDescription}";
        }
    }
}