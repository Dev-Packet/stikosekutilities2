using HarmonyLib;

namespace stikosekutilities2.Patches
{
    [HarmonyPatch(typeof(LootContainerInteract))]
    public static class LootContainerInteractPatch
    {

        public static bool NoCoins = false;

        [HarmonyPatch(nameof(LootContainerInteract.Interact))]
        [HarmonyPostfix]
        private static void Interact(LootContainerInteract __instance)
        {
            if (NoCoins)
            {
                ClientSend.PickupInteract(__instance.GetId());
            }
        }

    }
}
