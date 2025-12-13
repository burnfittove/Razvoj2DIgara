namespace GUI
{
    public class DisplayHealth : DisplayAttribute
    {
        private void Update()
        {
            attributeValue = player.Health.Value;
            multiplierValue = player.MaxHealth.Value;
        }

        protected override void UpdateText(float attrVal, float multVal)
        {
            tmpText.text = $"{attrVal:0.0}/{multVal:0.0}";
        }
    }
}