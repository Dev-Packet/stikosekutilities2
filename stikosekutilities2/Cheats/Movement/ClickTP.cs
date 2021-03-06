using stikosekutilities2.UI;
using UnityEngine;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class ClickTP : BaseCheat
    {
        public static KeyCode key = KeyCode.Mouse1;

        public ClickTP() : base("ClickTP", WindowID.Movement)
        {
        }

        public override void Update()
        {
            if (!InGame)
                return;

            if (Activated && Input.GetKeyDown(key))
            {
                PlayerMovement.Instance.GetRb().position = FindTpPos();
            }
        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
        }

        private static Vector3 FindTpPos()
        {
            Transform playerCam = PlayerMovement.Instance.playerCam;
            if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit raycastHit, 1500f))
            {
                Vector3 b = Vector3.zero;
                if (raycastHit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    b = Vector3.one;
                }
                return raycastHit.point + b;
            }
            return Vector3.zero;
        }

    }
}
