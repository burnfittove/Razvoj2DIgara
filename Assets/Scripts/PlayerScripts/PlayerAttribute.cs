namespace PlayerScripts
{
    public class PlayerAttribute
    {
        private float value;
        public float Value { get; private set; }
        private float multiplier;
        private float trueValue;
        private readonly float minMultiplier;
        private readonly float maxMultiplier;
        private readonly float minValue;
        private readonly float maxValue;

        public PlayerAttribute(float trueValue, float multiplier, float minMultiplier, float maxMultiplier,
            float minValue,
            float maxValue)
        {
            this.trueValue = trueValue;
            this.multiplier = multiplier;
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
            if (multiplier < 1) multiplier *= newMultiplierValue < .5f ? 2 * newMultiplierValue : newMultiplierValue; // Not as punishing if the player collects two items that decrease the multiplier
            else multiplier *= newMultiplierValue;
            // Set the multiplier to the minMultiplier value
            if (multiplier <= minMultiplier) multiplier = minMultiplier;
            // Apply the multiplier
            Value = trueValue * multiplier;
        }
    
        public void UpdateValue(float newValue)
        {
            // Exit if the value is 0
            if (newValue == 0) return;
        
            // Update the true attribute
            trueValue += newValue;
            // Recalculate the usable attribute
            Value = trueValue * multiplier;
        }
    }
}
