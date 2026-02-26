using System.Collections.Generic;
using System.Linq;
using Bullets;
using UnityEngine;

namespace PlayerScripts.Shooting
{
    public abstract class BulletPooling : MonoBehaviour
    {
        // public static BulletPooling Instance;
        public List<Bullet> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;

        private void Start()
        {
            // Create a list of bullets
            pooledObjects = new List<Bullet>();
            
            // Create n bullets
            for (var i = 0; i < amountToPool; i++)
            {
                CreateBullet();
            }
        }

        // Return inactive Bullets
        public Bullet GetPooledObject()
        {
            // Go through the whole list
            foreach (var t in pooledObjects)
            {
                // If the object is inactive, it means it is currently unused, so it should be shot as the next bullet
                if (!t.gameObject.activeInHierarchy)
                {
                    return t;
                }
            }
            
            // If there are no free bullets, create a new one and return it
            CreateBullet();
            return pooledObjects.Last();
        }

        private void CreateBullet()
        {
            // Create instance
            var tmp = Instantiate(objectToPool);
            // Disable it
            tmp.SetActive(false);
            // Add it to the list
            pooledObjects.Add(tmp.GetComponent<Bullet>());
        }
    }
}
