using Events;
using UnityEngine;

namespace PlayerScripts.States
{
    public class DeathState : State
    {
        protected override void OnEnter()
        {
            GameEventManager.Instance.miscEvents.PlayerDied();
            
            // Dim the player's color and rotate the sprite
            p.sr.color = new Color(0.4f, 0.4f, 0.4f, 0.7f);
            p.sr.transform.rotation = Quaternion.Euler(0, p.sr.transform.rotation.y, 90);
            
            // Disable collider
            p.TryGetComponent(out Collider2D collider);
            collider.enabled = false;
        }
    }
}