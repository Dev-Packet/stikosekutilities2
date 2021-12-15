namespace stikosekutilities2.Cheats
{

    public class GodMode : BaseCheat
    {
        public override void Update()
        {
            if (Activated)
            {
                PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;
                PlayerStatus.Instance.shield = PlayerStatus.Instance.maxShield;
            }

        }

    }
}
