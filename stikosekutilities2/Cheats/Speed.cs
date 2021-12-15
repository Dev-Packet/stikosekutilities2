namespace stikosekutilities2.Cheats
{
    public class Speed : BaseCheat
    {
        private static float originalMultiplier = -999;

        public override void Update()
        {
            if (Activated)
            {
                if (-originalMultiplier == -999)
                    originalMultiplier = PlayerStatus.Instance.currentSpeedArmorMultiplier;
                PlayerStatus.Instance.currentSpeedArmorMultiplier = 5000;
            }
            else
            {
                PlayerStatus.Instance.currentSpeedArmorMultiplier = originalMultiplier;
            }
        }

    }
}
