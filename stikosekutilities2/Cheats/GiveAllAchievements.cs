using Steamworks;
using stikosekutilities2.UI;
using System.Linq;

namespace stikosekutilities2.Cheats
{
    [Cheat]
    public class GiveAllAchievements : BaseCheat
    {
        public GiveAllAchievements() : base("Give all Achievements", WindowID.Other)
        {
        }

        protected override void RenderElements()
        {
            if(Button(Name))
            {
                SteamUserStats.Achievements.ToList().ForEach(a => a.Trigger(true));

                SteamUserStats.StoreStats();
            }
        }

    }
}
