using Steamworks;
using stikosekutilities2.UI;
using System.Linq;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class Achievements : BaseCheat
    {
        public Achievements() : base("Achievements", WindowID.Other)
        {
        }

        protected override void RenderElements()
        {
            if (Button("Give all Achievements"))
            {
                SteamUserStats.Achievements.ToList().ForEach(a => a.Trigger(true));

                SteamUserStats.StoreStats();
            }

            if (Button("Reset all Achievements"))
            {
                SteamUserStats.ResetAll(true);
                SteamUserStats.StoreStats();
            }
            
        }

    }
}
