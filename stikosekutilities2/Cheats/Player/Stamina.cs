using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class Stamina : BaseCheat
    {
        public Stamina() : base("Infinite stamina", WindowID.Player)
        {
        }

        public override void Update()
        {
            if (!InGame)
                return;

            if (Activated)
            {
                PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;
            }

        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
        }

    }
}
