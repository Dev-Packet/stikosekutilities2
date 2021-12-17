using stikosekutilities2.Patches;
using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class InstaKill : BaseCheat
    {
        public InstaKill() : base("InstaKill", WindowID.Player)
        {
        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);

            HitableMobPatch.InstaKill = Activated;
        }

    }
}
