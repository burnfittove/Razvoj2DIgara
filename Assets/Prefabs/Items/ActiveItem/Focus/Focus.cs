using System.Collections;
using Events;
using PlayerScripts;
using UnityEngine;

namespace Prefabs.Items.ActiveItem.Focus
{
    public class Focus : Item.ActiveItem.ActiveItem
    {
        [SerializeField] private float time;
        private float buffer;
        public override void UseActiveItem()
        {
            base.UseActiveItem();
            var attr = Random.Range(0, 7);

            switch (attr)
            {
                case 0:
                    GameEventManager.Instance.attributeUpdateEvents.MaxHealthChange(itemInformation.maxHealthDelta);
                    break;
                case 1:
                    GameEventManager.Instance.attributeUpdateEvents.SpeedChange(itemInformation.maxHealthDelta);
                    break;
                case 2:
                    GameEventManager.Instance.attributeUpdateEvents.DamageChange(itemInformation.maxHealthDelta);
                    break;
                case 3:
                    GameEventManager.Instance.attributeUpdateEvents.FireDelayChange(-itemInformation.maxHealthDelta);
                    break;
                case 4:
                    GameEventManager.Instance.attributeUpdateEvents.RangeChange(itemInformation.maxHealthDelta);
                    break;
                case 5:
                    GameEventManager.Instance.attributeUpdateEvents.ShotSpeedChange(itemInformation.maxHealthDelta);
                    break;
                case 6:
                    GameEventManager.Instance.attributeUpdateEvents.LuckChange(itemInformation.maxHealthDelta);
                    break;
            }
        }
    }
}
