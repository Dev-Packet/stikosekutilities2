using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class Hunger : BaseCheat
    {
        public Hunger() : base("No hunger", WindowID.Player)
        {
        }

        public override void Update()
        {
            if (!InGame)
                return;

            if (Activated)
            {
                PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
            }

        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
        }

    }
}
