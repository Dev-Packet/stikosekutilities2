using HarmonyLib;
using stikosekutilities2.Cheats;

namespace stikosekutilities2.Patches
{
    [HarmonyPatch(typeof(PlayerStatus))]
    public static class PlayerStatusPatch
    {

        [HarmonyPatch(typeof(PlayerStatus), "Awake")]
        private static void Prefix(PlayerStatus __instance)
        {
            Items.SuItems.Clear();
            Items.SuItems.AddRange(ItemManager.Instance.allItems.Values);
        }

    }
}
