using PlayerScripts;
using UnityEngine;

namespace Merchants
{
    public abstract class Merchant : MonoBehaviour
    {
        [SerializeField] protected GameObject[] items;
        [SerializeField] private Transform startingPos;
        [SerializeField] private Vector2 gapBetweenItems; // Default (1.5f, 1.2f);
        protected Player player;

        protected virtual void Awake()
        {
            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);

            // Disable/enable colliders whenever the player's currencies changes
            // EXAMPLE GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += _ => InitializeItemStates();
        }

        private void Start()
        {
            // Create all items
            SetItemPosition();
            InitializeItemStates();
        }

        protected abstract void InitializeItemStates();

        private void SetItemPosition()
        {
            // Return if array is empty for some reason
            if (items.Length == 0) return;
            
            // Get the y coordinate for the first row
            var pos = (Vector2)startingPos.position - new Vector2(gapBetweenItems.x, 0);

            // Go through all items
            for (var i = 0; i < items.Length; i++)
            {
                // Create the item and assign it to its slot in the array
                var instantiatedItem = Instantiate(items[i], pos, Quaternion.identity);
                // Make item buyable
                instantiatedItem.GetComponent<Item.Item>().isBuyable = true;
                items[i] = instantiatedItem;
                // Change the next items spawn position
                IncrementPosition(ref pos);
            }
        }

        private void IncrementPosition(ref Vector2 pos)
        {
            // If less than three items were created change the next x coordinate of the next item by the x coordinate of gapBetweenItems
            if (!Mathf.Approximately(pos.x, transform.position.x + gapBetweenItems.x))
            {
                pos.x += gapBetweenItems.x;
                return;
            }
            // If three items were created in one row, go to the next row
            pos.x -= gapBetweenItems.x * 2;
            pos.y -= gapBetweenItems.y;
        }
    }
}
