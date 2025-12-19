using Events;
using Items;
using TMPro;
using UnityEngine;

public class ShowItemDescription : MonoBehaviour
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

    private void UpdateItemDescriptionUI(Item item)
    {
        gameObject.SetActive(true);
        itemName.text = item.itemInformation.itemName;
        itemDescription.text = item.itemInformation.itemDescription;
    }
}
