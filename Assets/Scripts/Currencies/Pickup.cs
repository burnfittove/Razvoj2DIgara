using UnityEngine;

namespace Currencies
{
    public abstract class Pickup : MonoBehaviour
    {
        [SerializeField] protected int value = 1;
        [SerializeField] protected Collider2D triggerCol;

        private void Start()
        {
            if (triggerCol == null) triggerCol = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            OnPickupPickedUp();
        }

        protected abstract void OnPickupPickedUp();
    }
}