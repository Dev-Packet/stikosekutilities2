using BepInEx;
using BepInEx.Logging;
using stikosekutilities2.Cheats;
using stikosekutilities2.UI;
using stikosekutilities2.Utils;
using UnityEngine;

namespace stikosekutilities2
{
    [BepInPlugin(PluginConstants.GUID, PluginConstants.Name, PluginConstants.Version)]
    public class Plugin : MonoBehaviour
    {
        public static Plugin Instance { get; private set; }
        private static ManualLogSource Logger => Loader.Log;

        private RainbowColor rainbow;
        private string waterMarkText;

        private void Awake()
        {
            Instance = this;

            waterMarkText = $"{PluginConstants.Name} {Loader.FormattedVersion} by DevPacket";

            // Add Windows
            GUIRenderer.AddWindow(WindowID.Player, "Player", new(70, 90, 320, 400));
            GUIRenderer.AddWindow(WindowID.Movement, "Movement", new(400, 90, 320, 400));
            GUIRenderer.AddWindow(WindowID.Combat, "Combat", new(730, 90, 320, 400));
            GUIRenderer.AddWindow(WindowID.Other, "Other", new(1060, 90, 320, 400));

            rainbow = new RainbowColor(.2f);

            // Init rendering
            BaseCheat.ExecuteForAllModules(c => c.InitRender());

            LogLoadedMessage();

        }

        private static void LogLoadedMessage()
        {
            string loaded = $"Loaded {PluginConstants.Name} {Loader.FormattedVersion} by DevPacket! (H)";
            string githubURL = $"GitHub URL: {PluginConstants.RepositoryURL}";

            int lenght = (loaded.Length > githubURL.Length ? loaded.Length : githubURL.Length) + 1;

            string placeHolder = "";

            for (int i = 0; i < lenght; i++)
                placeHolder += '=';

            Logger.LogError(placeHolder);

            Logger.LogMessage(loaded);
            Logger.LogMessage(githubURL);

            Logger.LogError(placeHolder);
        }

        private void OnGUI()
        {
            // Draw ClickGUI
            GUIRenderer.DrawWindows();

            // Execute OnGUI for cheats
            BaseCheat.ExecuteForAllModules(cheat => cheat.OnGUI());

            // Draw Watermark
            int fontSize = 17;
            DrawingUtil.DrawText(waterMarkText, DrawingUtil.CenteredTextRect(waterMarkText, fontSize).x, 10, fontSize, rainbow.GetColor());
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
