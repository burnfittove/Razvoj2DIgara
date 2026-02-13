using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts.Shooting
{
    public interface IShooter
    {
        public void Shoot(Vector2 direction);
        public void GetDirection(InputAction.CallbackContext cursorWorldPosition);
        public void DecreaseDelay(ref float delay)
        {
            delay -= Time.deltaTime * 10;
        }
    }
}
