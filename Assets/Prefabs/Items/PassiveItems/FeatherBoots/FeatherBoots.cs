using Events;
using Item.PassiveItem;
using UnityEngine.InputSystem;

namespace Prefabs.Items.PassiveItems.FeatherBoots
{
    public class FeatherBoots : PassiveItem
    {
        // Only reduce the speed if the item increased it
        private bool increasedSpeed = false;
        
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.inputEvents.OnFirePressed += ChangeSpeedOnMove;
            base.OnItemPickedUp();
        }
        
        private void ChangeSpeedOnMove(InputAction.CallbackContext isPressed)
        {
            // Ignore the first input to prevent the item from increasing the speed twice
            if (isPressed.started) return;
            
            // Increase the speed if the player is shooting
            if (isPressed.performed)
            {
                GameEventManager.Instance.attributeUpdateEvents.SpeedChange(itemInformation.speedDelta);
                increasedSpeed = true;
            }

            // Decrease the speed if the player stops shooting and this item increased the speed
            if (!increasedSpeed) return;
            if (isPressed.canceled) GameEventManager.Instance.attributeUpdateEvents.SpeedChange(-itemInformation.speedDelta);
        }
    }
}
