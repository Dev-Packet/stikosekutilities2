namespace stikosekutilities2.Cheats
{
    internal class Speed
    {
        public static bool activated = true;

        private static float originalMultiplier = -999;

        public static void Update()
        {
            if (activated)
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
