using Events;
using Items.ItemEffects;
using UnityEngine;

namespace Items.PassiveItems.FeatherBoots
{
    public class FeatherBootsEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            base.Awake();
            GameEventManager.Instance.inputEvents.OnFirePressed += ChangeSpeedOnMove;
        }

        private void ChangeSpeedOnMove(float isPressed)
        {
            if (isPressed > 0.1f)
                GameEventManager.Instance.attributeUpdateEvents.SpeedChange(itemInformation.speedDelta);
            else
                GameEventManager.Instance.attributeUpdateEvents.SpeedChange(-itemInformation.speedDelta * 2);
        }
    }
}
