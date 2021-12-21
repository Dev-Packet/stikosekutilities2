using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class GodMode : BaseCheat
    {
        public GodMode() : base("GodMode", WindowID.Player)
        {
        }

        public override void Update()
        {
            if (!InGame)
                return;

            if (Activated)
            {
                PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;
                PlayerStatus.Instance.shield = PlayerStatus.Instance.maxShield;
            }

        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
        }

    }
}
