using stikosekutilities2.Patches;
using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class NoCoins : BaseCheat
    {
        public NoCoins() : base("NoCoins", WindowID.Player)
        {
        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);

            LootContainerInteractPatch.NoCoins = Activated;
        }

    }
}
