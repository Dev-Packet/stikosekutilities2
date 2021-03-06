using UnityEngine;
using static stikosekutilities2.Utils.DrawingUtil;

namespace stikosekutilities2.Utils
{
    public static class WelcomeScreen
    {
        private static bool
            init,
            updateAvailable;

        public static bool draw;

        public static void OnGUI(GameObject gameObject)
        {
            if (!init)
            {
                init = true;

                updateAvailable = VersionChecker.UpdateAvailable;
            }

            Event e = Event.current;

            if (e != null && e.isKey)
            {
                if (Input.GetKeyDown(e.keyCode))
                {
                    draw = false;

                    if (updateAvailable)
                        Object.Destroy(gameObject);

                    return;
                }
            }

            DrawWelcome();
        }

        private static void DrawWelcome()
        {
            if (!draw) return;

            //Black out
            DrawFullScreenColor(TransparentBlack);

            //Position Calculation
            float divider = 2f;
            Resolution res = Screen.currentResolution;
            float x = (res.width - res.width / divider) / 2f;
            float y = (res.height - res.height / divider) / 2f;
            Rect rect = new(x, y, res.width / divider, res.height / divider);

            //Draw middle rect
            DrawColor(updateAvailable ? new Color(0, 1, 0, 0.6f) : new Color(0, 1, 0, 0.6f), rect);

            #region WaterMark

            string waterMark = "<b>DevPacket's stikosekutilities2</b>";

            Rect waterMarkRect = CenteredTextRect(waterMark, 40);
            waterMarkRect.y -= (rect.y / 1.6f);

            GUI.Label(waterMarkRect, waterMark, GetTextStyle(40, Color.black));

            #endregion

            #region Press any Key to continue

            string continueText = "<i><b>Press any Key to continue...</b></i>";

            Rect continueRect = CenteredTextRect(continueText, 40);
            continueRect.y += (rect.y / 1.6f);

            GUI.Label(continueRect, continueText, GetTextStyle(40, Color.black));

            #endregion

            if (updateAvailable)
            {
                DrawCenteredText(
                "Welcome to DevPacket's stikosekutilities2," + "\n" +
                "the advanced muck utility mod!" + "\n" +
                "In order to use this mod," + "\n" +
                "update to the newest version!", 40, Color.white);
            }
            else
            {
                DrawCenteredText(
                "Welcome to DevPacket's stikosekutilities2," + "\n" +
                "the advanced muck utility mod!" + "\n" +
                "To open the ClickGUI press \"" + KeyCodeFormatter.KeyNames[KeyCode.RightShift] + "\"!", 40, Color.white);
            }

        }

    }
}
