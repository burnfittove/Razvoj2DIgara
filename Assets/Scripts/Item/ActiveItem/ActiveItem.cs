using Events;

namespace Item.ActiveItem
{
    public abstract class ActiveItem : Item
    {
        public int currentCharge;
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.itemEvents.ActiveItemAcquired(gameObject);
            HideItem();
        }

        protected override void Awake()
        {
            base.Awake();
            currentCharge = itemInformation.maxCharge;
        }

        public virtual void UseActiveItem()
        {
            currentCharge = 0;
        }
    }
}
