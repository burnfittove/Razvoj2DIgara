using System.Collections.Generic;
using System.Linq;
using Events;
using UnityEngine;

namespace PlayerScripts
{
    public class DetectNearbyItems : MonoBehaviour
    {
        private readonly ISet<Item.Item> nearbyItemSet = new HashSet<Item.Item>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Item")) return;
            nearbyItemSet.Add(other.GetComponent<Item.Item>());
        }

        private Item.Item GetNearestItem()
        {
            if (nearbyItemSet.Count == 1) return nearbyItemSet.First();
         
            var min = float.MaxValue;
            var nearestItem = nearbyItemSet.First();
            
            foreach (var item in nearbyItemSet)
            {
                var distance = Vector2.Distance(item.transform.position, transform.position);
                if (!(distance < min)) continue;
                min = distance;
                nearestItem = item;
            }
            
            return nearestItem;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Item")) return;
            nearbyItemSet.Remove(other.GetComponent<Item.Item>());
            GameEventManager.Instance.itemEvents.NearbyItemLost();
        }

        private void Update()
        {
            if (nearbyItemSet.Count == 0) return;
            GameEventManager.Instance.itemEvents.NearbyItemDetected(GetNearestItem());
        }
    }
}