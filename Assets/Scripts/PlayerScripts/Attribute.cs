using System;
using Saving;
using UnityEngine;

namespace PlayerScripts
{
    [Serializable]
    public class Attribute
    {
        public float value;
        public float multiplier;
        public float trueValue;
        [SerializeField] private float minMultiplier;
        [SerializeField] private float maxMultiplier;
        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;

        public Attribute(float trueValue, float multiplier, float minMultiplier, float maxMultiplier,
            float minValue,
            float maxValue)
        {
            this.trueValue = trueValue;
            this.multiplier = multiplier;
            this.minMultiplier = minMultiplier;
            this.maxMultiplier = maxMultiplier;
            this.minValue = minValue;
            this.maxValue = maxValue;
            value = trueValue * multiplier;
        }

        public void UpdateMultiplier(float newMultiplierValue)
        {
            // Exit if the value is 0
            if (newMultiplierValue == 0) return;
        
            // Update the multiplier
            if (multiplier < 1) multiplier *= newMultiplierValue < .5f ? 2 * newMultiplierValue : newMultiplierValue; // Not as punishing if the player collects two items that decrease the multiplier
            else multiplier *= newMultiplierValue;
            // Set the multiplier to the minMultiplier value
            if (multiplier <= minMultiplier) multiplier = minMultiplier;
            // Set the multiplier to the maxMultiplier value
            if (multiplier >= maxMultiplier) multiplier = maxMultiplier;
            // Apply the multiplier
            value = trueValue * multiplier;
        }
    
        public void UpdateValue(float newValue)
        {
            // Update the true attribute
            trueValue += newValue;
            if (trueValue < minValue) trueValue = minValue;
            if (trueValue > maxValue) trueValue = maxValue;
            // Recalculate the usable attribute
            value = trueValue * multiplier;
        }
        
        public void UpdateValue()
        {
            // Update value based on min and max values
            if (trueValue < minValue) trueValue = minValue;
            if (trueValue > maxValue) trueValue = maxValue;
            // Recalculate the usable attribute
            value = trueValue * multiplier;
        }

        public void ChangeConstantMaxValue(float newConstantMaxValue)
        {
            maxValue = newConstantMaxValue;
        }
        
        public void SetMultiplier(float newMultiplier)
        {
            // Update the multiplier
            multiplier = newMultiplier;
            // Set the multiplier to the minMultiplier value
            if (multiplier <= minMultiplier) multiplier = minMultiplier;
            // Set the multiplier to the maxMultiplier value
            if (multiplier >= maxMultiplier) multiplier = maxMultiplier;
            // Apply the multiplier
            value = trueValue * multiplier;
        }
        
        public void SetValue(float newValue)
        {
            // Update the true attribute
            trueValue = newValue;
            if (trueValue < minValue) trueValue = minValue;
            if (trueValue > maxValue) trueValue = maxValue;
            // Recalculate the usable attribute
            value = trueValue * multiplier;
        }
    }
}
