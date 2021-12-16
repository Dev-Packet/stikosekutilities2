using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class Speed : BaseCheat
    {
        private static float originalMultiplier = -999;
        private float multiplier = 1;

        public Speed() : base("Speed", WindowID.Player)
        {
        }

        public override void Update()
        {
            if (PlayerStatus.Instance == null)
                return;

            if (originalMultiplier == -999)
                originalMultiplier = PlayerStatus.Instance.currentSpeedArmorMultiplier;

            if (Activated)
            {
                PlayerStatus.Instance.currentSpeedArmorMultiplier = multiplier;
            }
            else
            {
                PlayerStatus.Instance.currentSpeedArmorMultiplier = originalMultiplier;
            }
        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
            multiplier = Slider(1, 5000, multiplier);
        }

    }
}
