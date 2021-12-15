namespace stikosekutilities2.Cheats
{

    internal class Stamina
    {
        public static bool activated = true;

        public static void Update()
        {
            if (activated)
            {
                PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;
            }

        }

    }
}
