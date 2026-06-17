using PlayerScripts.Shooting;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.Bat
{
    public class BatFamiliar : Familiar.Familiar
    {
        // Stats
        [SerializeField] private Transform batPosition;
        [SerializeField] private float fireDelay;
        [SerializeField] private float fireDelayBuffer;
        [SerializeField] private float damage;
        [SerializeField] private float shotSpeed;
        [SerializeField] private float range;
        [SerializeField] private LayerMask enemyLayer;
        
        // Finding enemies
        public float sightRange;
        private RaycastHit2D[] hits;

        // Player ref
        private Transform player;

        private void Start()
        {
            player = transform.parent;
            fireDelayBuffer = 0;
        }

        protected override void Update()
        {
            Shoot();
            
            fireDelayBuffer -= Time.deltaTime * 10;
            
            base.Update();
        }

        private void Shoot()
        {
            // If the bat can't fire, return
            if (fireDelayBuffer > 0) return;

            var direction = GetDirectionToClosestEnemyInRange();
            // If the direction is zero, there are no enemies in range, therefore, return
            if (direction == Vector2.zero) return;
            
            // Use the PlayerBulletPooling Script to shoot bullets
            var bullet = PlayerBulletPooling.Instance.GetPooledObject();
            if (bullet is not null)
            {
                bullet.transform.position = batPosition.position;
                bullet.Initialize(direction, shotSpeed, damage, range, .7f);
                bullet.gameObject.SetActive(true);
            }
            
            // Set fireDelayBuffer
            fireDelayBuffer = fireDelay;
        }

        private Vector2 GetDirectionToClosestEnemyInRange()
        {
            // Check if the player is within range
            hits = Physics2D.CircleCastAll(batPosition.position, sightRange, Vector2.zero, Mathf.Infinity, enemyLayer);

            switch (hits.Length)
            {
                // If there are no enemies in range, return Vector2.zero
                case 0:
                    return Vector2.zero;
                // If there is only one enemy in range, it's the closest
                case 1:
                    return hits[0].transform.position - batPosition.position;
            }

            // Otherwise, find the closest enemy
            var minDistance = Vector2.positiveInfinity;
            foreach (var hit in hits)
            {
                // If the distance between an enemy transform and the bat is smaller than the previously-defined smallest distance, then it becomes the smallest distance
                var distance = hit.distance;
                if (distance < minDistance.magnitude) minDistance = hit.point;
            }

            return minDistance;
        }
    }
}
