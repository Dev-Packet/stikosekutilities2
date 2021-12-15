namespace stikosekutilities2.Cheats
{

    public class Stamina : BaseCheat
    {
        public override void Update()
        {
            if (Activated)
            {
                PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;
            }

        }

    }
}
