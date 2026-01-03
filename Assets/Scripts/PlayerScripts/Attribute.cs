using Unity.VisualScripting;

namespace PlayerScripts
{
    public class Attribute
    {
        private float value;
        public float Value { get; private set; }
        private float multiplier;
        public float Multiplier { get;  private set; }
        private float trueValue;
        private float minMultiplier;
        private float maxMultiplier;
        private float minValue;
        private float maxValue;

        public Attribute(float trueValue, float multiplier, float minMultiplier, float maxMultiplier,
            float minValue,
            float maxValue)
        {
            this.trueValue = trueValue;
            Multiplier = multiplier;
            this.minMultiplier = minMultiplier;
            this.maxMultiplier = maxMultiplier;
            this.minValue = minValue;
            this.maxValue = maxValue;
            Value = trueValue * multiplier;
        }

        public void UpdateMultiplier(float newMultiplierValue)
        {
            // Exit if the value is 0
            if (newMultiplierValue == 0) return;
        
            // Update the multiplier
            if (Multiplier < 1) Multiplier *= newMultiplierValue < .5f ? 2 * newMultiplierValue : newMultiplierValue; // Not as punishing if the player collects two items that decrease the multiplier
            else Multiplier *= newMultiplierValue;
            // Set the multiplier to the minMultiplier value
            if (Multiplier <= minMultiplier) Multiplier = minMultiplier;
            // Set the multiplier to the maxMultiplier value
            if (Multiplier >= maxMultiplier) Multiplier = maxMultiplier;
            // Apply the multiplier
            Value = trueValue * Multiplier;
        }
    
        public void UpdateValue(float newValue)
        {
            // Update the true attribute
            trueValue += newValue;
            if (trueValue < minValue) trueValue = minValue;
            if (trueValue > maxValue) trueValue = maxValue;
            // Recalculate the usable attribute
            Value = trueValue * Multiplier;
        }
        
        public void UpdateValue()
        {
            // Update value based on min and max values
            if (trueValue < minValue) trueValue = minValue;
            if (trueValue > maxValue) trueValue = maxValue;
            // Recalculate the usable attribute
            Value = trueValue * Multiplier;
        }

        public void ChangeConstantMaxValue(float newConstantMaxValue)
        {
            maxValue = newConstantMaxValue;
        }
    }
}
