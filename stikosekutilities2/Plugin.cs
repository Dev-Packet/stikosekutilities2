using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using stikosekutilities2.Cheats;
using stikosekutilities2.UI;
using stikosekutilities2.Utils;
using System;
using System.Diagnostics;
using UnityEngine;

namespace stikosekutilities2
{
    [BepInPlugin(PluginConstants.GUID, PluginConstants.Name, PluginConstants.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log => Instance.Logger;
        public static Plugin Instance { get; private set; }
        public Harmony HarmonyInstance { get; private set; }

        private void Awake()
        {
            Instance = this;
            WelcomeScreen.draw = true;

            // Download Newtosoft.Json
            Utilities.DownloadJsonLibrary();

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
                HarmonyInstance = new Harmony(PluginConstants.GUID);
                HarmonyInstance.PatchAll();

                foreach (var method in HarmonyInstance.GetPatchedMethods())
                {
                    Logger.LogInfo($"Patched: {method.DeclaringType.FullName}.{method.Name}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error initializing Harmony: {ex}");
            }

            // Add Windows
            GUIRenderer.AddWindow(WindowID.Player, "Player", new(70, 90, 320, 400));
            GUIRenderer.AddWindow(WindowID.Movement, "Movement", new(400, 90, 320, 400));

            // Init rendering
            BaseCheat.ExecuteForAllModules(c => c.InitRender());

            Logger.LogInfo($"Plugin stikosekutilities2 is loaded!");
        }

        private void OnGUI()
        {
            // Draw WelcomeScreen
            WelcomeScreen.OnGUI(gameObject);

            // Draw ClickGUI
            GUIRenderer.DrawWindows();

            // Execute OnGUI for cheats
            BaseCheat.ExecuteForAllModules(cheat => cheat.OnGUI());
        }

        private void Update()
        {
            // Hide & Show ClickGUI
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                GUIRenderer.Shown = !GUIRenderer.Shown;
            }

            GUIRenderer.Update();

            // Execute Update in cheats
            BaseCheat.ExecuteForAllModules(cheat => cheat.Update());
        }

    }
}
