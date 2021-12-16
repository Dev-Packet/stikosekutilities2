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
            DrawWindowEvent();

            if (Draggable)
            {
                GUI.DragWindow(new Rect(0, 0, 10000, 20));
            }
        }

    }
}
