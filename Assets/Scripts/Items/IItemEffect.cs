namespace Items
{
    public interface IItemEffect
    {
        public void OnItemPickup();
        public virtual void ItemEffect() {}
    }
}