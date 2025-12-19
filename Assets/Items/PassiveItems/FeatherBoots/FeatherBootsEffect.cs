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
            GameEventManager.Instance.InputEvents.OnFirePressed += ChangeSpeedOnMove;
        }

        private void ChangeSpeedOnMove(float isPressed)
        {
            if (isPressed > 0.1f)
                Player.Speed.UpdateValue(itemInformation.speedDelta);
            else
                Player.Speed.UpdateValue(-itemInformation.speedDelta * 2);
        }
    }
}
