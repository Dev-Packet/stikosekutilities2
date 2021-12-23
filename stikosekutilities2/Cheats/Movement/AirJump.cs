using stikosekutilities2.UI;
using UnityEngine;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class AirJump : BaseCheat
    {
        public AirJump() : base("AirJump", WindowID.Movement)
        {
        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
        }


        public override void Update()
        {
            if (InGame && Input.GetKeyDown(SaveManager.Instance.state.jump) && Activated)
            {
                var velocity = PlayerMovement.Instance.GetRb().velocity;

                velocity.y = 20f;

                PlayerMovement.Instance.GetRb().velocity = velocity;
            }
        }

    }
}
