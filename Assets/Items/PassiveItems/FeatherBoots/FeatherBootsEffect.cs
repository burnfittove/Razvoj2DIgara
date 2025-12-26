using Events;
using Items.ItemEffects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Items.PassiveItems.FeatherBoots
{
    public class FeatherBootsEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            base.Awake();
            GameEventManager.Instance.inputEvents.OnFirePressed += ChangeSpeedOnMove;
        }

        private void ChangeSpeedOnMove(InputAction.CallbackContext isPressed)
        {
            if (isPressed.performed) return;
            
            if (isPressed.started)
                GameEventManager.Instance.attributeUpdateEvents.SpeedChange(itemInformation.speedDelta);
            else
                GameEventManager.Instance.attributeUpdateEvents.SpeedChange(-itemInformation.speedDelta);
        }
    }
}
