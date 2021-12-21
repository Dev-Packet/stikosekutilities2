using stikosekutilities2.Utils;
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

        public Rect WindowRect;
        public static int TopBarThickness = 20;

        public static string
            TopHex = "#2d2f31",
            RestHex = "#3c4649",
            BorderHex = "#353a3c";

        public static Color
            Top = Color.white,
            Rest = Color.black,
            Border = Color.white;

        private static bool colorInit;
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
            if(!colorInit)
            {
                ColorUtility.TryParseHtmlString(BorderHex, out Border);
                ColorUtility.TryParseHtmlString(RestHex, out Rest);
                ColorUtility.TryParseHtmlString(TopHex, out Top);

                colorInit = true;
            }
            
            DrawingUtil.DrawColor(Border, new Rect(0, 0, WindowRect.width, WindowRect.height));
            
            DrawingUtil.DrawColor(Rest, new Rect(5, TopBarThickness - 5, WindowRect.width - 10, WindowRect.height - TopBarThickness));

            //Draw top bar
            DrawingUtil.DrawColor(Top, new Rect(0, 0, WindowRect.width, TopBarThickness));
            
            DrawingUtil.DrawText(Text, new Rect(0, 0, WindowRect.width, TopBarThickness), TopBarThickness - 3, Color.white);
            DrawWindowEvent();

            if (Draggable)
            {
              
                GUI.DragWindow(new Rect(0, 0, 10000, 20));
            }
        }

    }
}
