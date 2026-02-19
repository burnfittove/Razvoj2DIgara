using UnityEngine;

namespace PlayerScripts.Shooting
{
    public class PlayerBulletPooling : BulletPooling
    {
        public static PlayerBulletPooling Instance;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) Debug.LogError("Multiple instances of PlayerBulletPooling detected!");
            Instance = this;
        }
    }
}