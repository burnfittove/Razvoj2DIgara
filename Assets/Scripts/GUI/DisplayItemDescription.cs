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
            itemName.text = $"{item.itemInformation.itemName} | {item.itemInformation.itemQuality}";
            itemDescription.text = $"{(item.isBuyable ? $"Price: ${item.itemInformation.price}/{item.itemInformation.vampirePrice} max health\n" : "")}{item.itemInformation.itemDescription}";
        }
    }
}