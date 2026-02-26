using System;
using UnityEngine;

namespace Item.Familiars
{
    public class FamiliarRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Transform rotationPoint;

        private void Update()
        {
            transform.RotateAround(rotationPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}
