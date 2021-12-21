using HarmonyLib;
using UnityEngine;

namespace stikosekutilities2.Patches
{
    [HarmonyPatch(typeof(HitableMob))]
    public static class HitableMobPatch
    {
        public static bool InstaKill;

        [HarmonyPatch(nameof(HitableMob.Hit))]
        [HarmonyPrefix]
        public static void Hit(HitableMob __instance, ref int damage, ref float sharpness, int hitEffect, Vector3 hitPos, int hitWeaponType)
        {
            if (InstaKill)
            {
                // Changes parameters to gain more damage
                damage = __instance.maxHp;
                sharpness = damage;
            }
        }

    }
}
