namespace stikosekutilities2.Cheats
{

    internal class Godmode
    {
        public static bool activated = true;

        public static void Update()
        {
            if (activated)
            {
                PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;
                PlayerStatus.Instance.shield = PlayerStatus.Instance.maxShield;
            }

        }

    }
}
