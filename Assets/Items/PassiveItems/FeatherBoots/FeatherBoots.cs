using Events;
using Item.PassiveItem;
using UnityEngine.InputSystem;

namespace Items.PassiveItems.FeatherBoots
{
    public class FeatherBoots : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.inputEvents.OnFirePressed += ChangeSpeedOnMove;
            base.OnItemPickedUp();
        }
        
        private void ChangeSpeedOnMove(InputAction.CallbackContext isPressed)
        {
            if (isPressed.started) return;
            
            if (isPressed.performed)
                GameEventManager.Instance.attributeUpdateEvents.SpeedChange(itemInformation.speedDelta);
            else
                GameEventManager.Instance.attributeUpdateEvents.SpeedChange(-itemInformation.speedDelta);
        }
    }
}
