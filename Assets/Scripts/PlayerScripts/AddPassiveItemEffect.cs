using Events;
using Items;
using UnityEngine;

namespace PlayerScripts
{
    public class AddPassiveItemEffect : MonoBehaviour
    {
        private void Awake()
        {
            GameEventManager.Instance.PassiveItemEvents.OnPassiveItemAcquired += AddPassiveItem;
        }

        public void AddPassiveItem(IItemEffect item)
        {
            
        }
    }
}