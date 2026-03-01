using UnityEngine.SceneManagement;

namespace Item.PassiveItem
{
    public abstract partial class PassiveItem : Item
    {
        private void Start()
        {
            // Run a method on the start of a room
            SceneManager.sceneLoaded += (_, _) => RoomStartEffect();
        }

        protected virtual void RoomStartEffect() {}

        /// <summary>
        /// OnItemPickedUp runs when the player touches the item. This method must be overriden and any attribute changes or event subscriptions need to be handled before base.OnItemPickedUp
        /// </summary>
        protected override void OnItemPickedUp()
        {
            if (!itemInformation.isPersistantPassive) Destroy(gameObject);
            HideItem();
            transform.SetParent(player.transform);
        }
    }
}