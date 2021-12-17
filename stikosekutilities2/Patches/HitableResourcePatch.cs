using HarmonyLib;
using UnityEngine;

namespace stikosekutilities2.Patches
{
    [HarmonyPatch(typeof(HitableResource))]
    public static class HitableResourcePatch
    {

        public static bool InstaMine;

        [HarmonyPatch(nameof(HitableResource.Hit))]
        [HarmonyPrefix]
        private static void Prefix(HitableResource __instance, ref int damage, ref float sharpness, int hitEffect, Vector3 pos, int hitWeaponType)
        {
            if (InstaMine)
            {
                damage = __instance.maxHp;
                sharpness = damage;
            }
        }

    }
}
