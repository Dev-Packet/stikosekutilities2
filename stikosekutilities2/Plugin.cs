using BepInEx;
using BepInEx.Logging;
using stikosekutilities2.Cheats;
using stikosekutilities2.UI;
using stikosekutilities2.Utils;
using stikosekutilities2.Utils.Screens;
using System.Diagnostics;
using UnityEngine;

namespace stikosekutilities2
{
    [BepInPlugin(PluginConstants.GUID, PluginConstants.Name, PluginConstants.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log => Instance.Logger;
        public static Plugin Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            WelcomeScreen.draw = true;

            Utilities.DownloadJsonLibrary();

            if (VersionChecker.UpdateAvailable)
            {
                // Cancel loading
                Logger.LogWarning($"Outdated version of {PluginConstants.Name}! Canceling loading!");
                Process.Start(PluginConstants.RepositoryURL);
                return;
            }

            GUIRenderer.AddWindow(WindowID.Player, "Sugma", new(70, 90, 320, 400));

            BaseCheat.ExecuteForAllModules(c => c.InitRender());

            Logger.LogInfo($"Plugin stikosekutilities2 is loaded!");
        }

        private void OnGUI()
        {
            WelcomeScreen.OnGUI(gameObject);

            GUIRenderer.DrawWindows();

            BaseCheat.ExecuteForAllModules(cheat => cheat.OnGUI());
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.RightShift))
            {
                GUIRenderer.Shown = !GUIRenderer.Shown;
            }

            GUIRenderer.Update();

            BaseCheat.ExecuteForAllModules(cheat => cheat.Update());
        }

    }
}
