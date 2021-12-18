using stikosekutilities2.UI;
using UnityEngine;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class WaterFloat : BaseCheat
    {
        private static Rigidbody Rigidbody => PlayerMovement.Instance.GetRb();

        public WaterFloat() : base("WaterFloat", WindowID.Movement)
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

            var pos = Rigidbody.position;
            if (Activated && PlayerMovement.Instance.transform.position.y < World.Instance.water.position.y + 2)
            {
                // Makes you slide to the sides

                Rigidbody.velocity = Vector3.ProjectOnPlane(PlayerMovement.Instance.GetRb().velocity, Vector3.up);

                pos.y = World.Instance.water.position.y + 2;

                // Float above Water
                Rigidbody.position = pos;
            }
        }

    }
}
