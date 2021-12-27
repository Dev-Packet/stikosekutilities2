using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using stikosekutilities2.Utils;
using System;
using System.Diagnostics;
using System.Reflection;

namespace stikosekutilities2
{
    [BepInPlugin(PluginConstants.GUID, PluginConstants.Name, PluginConstants.Version)]
    public class Loader : BaseUnityPlugin
    {
        public static ManualLogSource Log => Instance.Logger;
        public static Loader Instance { get; private set; }

        public Harmony HarmonyInstance { get; private set; }

        public static string FormattedVersion { get; private set; }

        private void Awake()
        {
            Instance = this;
            FormattedVersion = Utilities.FormatAssemblyVersion(true);
            WelcomeScreen.draw = true;

            if (VersionChecker.UpdateAvailable)
            {
                // Cancel loading
                Logger.LogWarning($"Outdated version of {PluginConstants.Name}! Canceling loading!");
                Process.Start(PluginConstants.RepositoryURL);
                return;
            }

            // Init Harmony
            try
            {
                // Create Harmony Instance
                HarmonyInstance = new Harmony(PluginConstants.GUID);
                CustomPatchAll();

                // Log all patched methods
                foreach (var method in HarmonyInstance.GetPatchedMethods())
                {
                    Logger.LogInfo($"Patched: {method.DeclaringType.FullName}.{method.Name}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error initializing Harmony: {ex}");
            }

            // Create Plugin instance.
            gameObject.AddComponent<Plugin>();
        }

        private void OnGUI()
        {
            // Draw WelcomeScreen
            WelcomeScreen.OnGUI(gameObject);
        }

        private void CustomPatchAll()
        {
            // Get all types from current assembly.
            AccessTools.GetTypesFromAssembly(Assembly.GetExecutingAssembly()).Do(type =>
            {
                try
                {
                    // Patch type
                    new PatchClassProcessor(HarmonyInstance, type).Patch();
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Failed to patch \"{type.FullName}\": {ex}!");
                }
            });
        }

    }
}
