namespace stikosekutilities2.Cheats
{

    internal class Hunger
    {
        public static bool activated = true;

        public static void Update()
        {
            if (activated)
            {
                PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
            }

        }

    }
}
