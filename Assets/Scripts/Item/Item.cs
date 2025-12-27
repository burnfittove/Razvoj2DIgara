using UnityEngine;

namespace Item
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected ItemInformationSo itemInformation;
        public ItemInformationSo ItemInformation => itemInformation;
        
        protected abstract void OnItemPickedUp();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            OnItemPickedUp();
        }
    }
}