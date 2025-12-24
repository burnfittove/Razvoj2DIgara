namespace GUI
{
    public class DisplayHealth : DisplayAttribute
    {
        private void Update()
        {
            value = player.Health.Value;
            multiplierValue = player.MaxHealth.Value;
        }

        protected override void UpdateText()
        {
            tmpText.text = $"{value:0.0}/{multiplierValue:0.0}";
        }
    }
}