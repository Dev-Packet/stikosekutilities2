namespace stikosekutilities2.Cheats
{

    public class Hunger : BaseCheat
    {

        public override void Update()
        {
            if (Activated)
            {
                PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
            }

        }

    }
}
