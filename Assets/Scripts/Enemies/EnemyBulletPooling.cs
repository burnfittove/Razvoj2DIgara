using PlayerScripts.Shooting;
using UnityEngine;

namespace Enemies
{
    public class EnemyBulletPooling : BulletPooling
    {
        public static EnemyBulletPooling Instance;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) Debug.LogError("Multiple instances of EnemyBulletPooling detected!");
            Instance = this;
        }
    }
}