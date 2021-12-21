using stikosekutilities2.Patches;
using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class InstaMine : BaseCheat
    {
        public InstaMine() : base("InstaMine", WindowID.Player)
        {
        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);

            HitableResourcePatch.InstaMine = Activated;
        }

    }
}
