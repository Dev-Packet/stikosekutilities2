using System;
using UnityEngine;

namespace stikosekutilities2.UI
{
    public class WindowManager
    {
        #region Variables
        public bool Shown { get; set; } = true;
        public bool Draggable { get; set; } = true;
        public bool AllowOffScreen { get; set; } = false;

        public event Action DrawWindowEvent = delegate { };

        public string Text { get; set; } = "";

        public GUIStyle WindowStyle { get; set; }
        public WindowID WindowId { get; private set; }

        private Rect WindowRect;
        public static int TopBarThickness = 20;
        public static string TopHex = "#2d2f31";
        public static string RestHex = "#3c4649";
        public static Color top = Color.white;
        public static Color rest = Color.black;
        public static string BorderHex = "#353a3c";
        public static Color border = Color.white;

        #endregion



        public WindowManager(WindowID windowId, Rect windowRect)
        {
            WindowId = windowId;
            WindowRect = windowRect;
        }

        public WindowManager(WindowID windowId)
        {
            WindowId = windowId;
        }

        public void RenderWindow()
        {
            if (!Shown)
                return;

            if (WindowStyle == null || WindowStyle == GUIStyle.none)
            {
                WindowStyle = GUI.skin.window;
            }

            WindowRect = GUI.Window((int)WindowId, WindowRect, DrawWindow, Text, WindowStyle);
          


            if (!AllowOffScreen)
            {
                WindowRect.x = Mathf.Clamp(WindowRect.x, 0, Screen.currentResolution.width - WindowRect.width);
                WindowRect.y = Mathf.Clamp(WindowRect.y, 0, Screen.currentResolution.height - WindowRect.height);
            }

        }

        /// <summary>
        /// Draws the Elements of the Window.
        /// </summary>
        /// <param name="id"></param>
        void DrawWindow(int id)
        {
            if (ColorUtility.TryParseHtmlString(BorderHex, out border))
            {
                Utils.DrawingUtil.DrawColor(border, new Rect(0, 0, WindowRect.width, WindowRect.height));
            }
            if (ColorUtility.TryParseHtmlString(RestHex, out rest))
            {
                Utils.DrawingUtil.DrawColor(rest, new Rect(5, TopBarThickness - 5, WindowRect.width - 10, WindowRect.height - TopBarThickness));
            }
            if (ColorUtility.TryParseHtmlString(TopHex, out top))
            {
                //Draw top bar
                Utils.DrawingUtil.DrawColor(top, new Rect(0, 0, WindowRect.width, TopBarThickness));
            }
           

            Utils.DrawingUtil.DrawText(Text, new Rect(0, 0, WindowRect.width, TopBarThickness), TopBarThickness - 3, Color.white);
            DrawWindowEvent();

            if (Draggable)
            {
              
                GUI.DragWindow(new Rect(0, 0, 10000, 20));
            }
        }

    }
}
