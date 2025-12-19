using System.Collections.Generic;
using System.Linq;
using Events;
using Items;
using UnityEngine;

namespace PlayerScripts
{
    public class DetectNearbyItems : MonoBehaviour
    {
        private Transform[] nearbyItems;
        public ISet<Item> nearbyItemSet = new HashSet<Item>();
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, 4.2f);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Item") return;
            nearbyItemSet.Add(other.GetComponent<Item>());
        }

        private Item GetNearestItem()
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
            if (other.tag != "Item") return;
            nearbyItemSet.Remove(other.GetComponent<Item>());
            GameEventManager.Instance.itemEvents.NearbyItemLost();
        }

        private void Update()
        {
            if (nearbyItemSet.Count == 0) return;
            GameEventManager.Instance.itemEvents.NearbyItemDetected(GetNearestItem());
        }
    }
}