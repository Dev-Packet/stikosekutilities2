using stikosekutilities2.UI;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class ReviveAll : BaseCheat
    {
        public ReviveAll() : base("Revive All", WindowID.Other)
        {
        }

        protected override void RenderElements()
        {
            if(Button(Name))
            {
                foreach(PlayerManager manager in GameManager.players.Values)
                {
                    if (manager == null || !manager.dead || manager.disconnected)
                        continue;

                    ClientSend.RevivePlayer(manager.id, -1, false);
                }
            }
        }

    }
}
