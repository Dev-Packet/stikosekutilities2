using UnityEngine;

namespace stikosekutilities2.Cheats
{

    internal class Clicktp
    {
        public static bool activated = true;
        public static KeyCode key = KeyCode.Mouse1;

        public static void Update()
        {
            if (activated && Input.GetKeyDown(key))
            {
                PlayerMovement.Instance.GetRb().position = Clicktp.FindTpPos(); ;
            }

        }

        public static Vector3 FindTpPos()
        {
            Transform playerCam = PlayerMovement.Instance.playerCam;
            RaycastHit raycastHit;
            if (Physics.Raycast(playerCam.position, playerCam.forward, out raycastHit, 1500f))
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
