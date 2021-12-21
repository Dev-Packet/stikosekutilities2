using stikosekutilities2.UI;
using UnityEngine;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class Fly : BaseCheat
    {
        public Fly() : base("Fly", WindowID.Movement)
        {
        }

        public override void Update()
        {
            if (!InGame)
                return;

            if (Activated)
            {
				PlayerMovement.Instance.GetRb().velocity = new Vector3(0f, 0f, 0f);
				float speed = Input.GetKey(KeyCode.LeftControl) ? 0.5f : (Input.GetKey(InputManager.sprint) ? 1f : 0.5f);
				if (Input.GetKey(InputManager.jump))
				{
					PlayerStatus.Instance.transform.position = new Vector3(PlayerStatus.Instance.transform.position.x, PlayerStatus.Instance.transform.position.y + speed, PlayerStatus.Instance.transform.position.z);
				}
				Vector3 playerTransformPosVec = PlayerStatus.Instance.transform.position;
				if (Input.GetKey(InputManager.forward))
				{
					PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x + Camera.main.transform.forward.x * Camera.main.transform.up.y * speed, playerTransformPosVec.y + Camera.main.transform.forward.y * speed, playerTransformPosVec.z + Camera.main.transform.forward.z * Camera.main.transform.up.y * speed);
				}
				if (Input.GetKey(InputManager.backwards))
				{
					PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x - Camera.main.transform.forward.x * Camera.main.transform.up.y * speed, playerTransformPosVec.y - Camera.main.transform.forward.y * speed, playerTransformPosVec.z - Camera.main.transform.forward.z * Camera.main.transform.up.y * speed);
				}
				if (Input.GetKey(InputManager.right))
				{
					PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x + Camera.main.transform.right.x * speed, playerTransformPosVec.y, playerTransformPosVec.z + Camera.main.transform.right.z * speed);
				}
				if (Input.GetKey(InputManager.left))
				{
					PlayerStatus.Instance.transform.position = new Vector3(playerTransformPosVec.x - Camera.main.transform.right.x * speed, playerTransformPosVec.y, playerTransformPosVec.z - Camera.main.transform.right.z * speed);
				}
			}

        }

        protected override void RenderElements()
        {
            Activated = Toggle(Name, Activated);
        }

    }
}
