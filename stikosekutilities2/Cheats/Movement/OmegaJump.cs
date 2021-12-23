using stikosekutilities2.UI;
using stikosekutilities2.Utils;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class OmegaJump : BaseCheat
    {
        private static float origJumpForce = -69;

        public OmegaJump() : base("OmegaJump", WindowID.Movement)
        {
        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
        }

        public override void Update()
        {
            if (!InGame)
                return;

            if (!Activated)
                return;

            if (origJumpForce == -69)
            {
                origJumpForce = PlayerMovement.Instance.GetFieldValue<float>("jumpForce");
            }

            PlayerMovement.Instance.SetFieldValue("jumpForce", origJumpForce * 2);
        }

    }
}
