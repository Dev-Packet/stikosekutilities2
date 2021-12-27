using HarmonyLib;

namespace stikosekutilities2.Patches
{
    [HarmonyPatch(typeof(PlayerStatus))]
    public static class PlayerStatusPatch
    {
        public static bool GodMode;

        [HarmonyPatch("HandleDamage")]
        [HarmonyPrefix]
        public static bool HandleDamage(PlayerStatus __instance)
        {
            if(GodMode)
            {
                ClientSend.PlayerHp(__instance.maxHp, __instance.maxHp);
            }

            return !GodMode;
        }

    }
}
