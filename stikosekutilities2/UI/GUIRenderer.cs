using stikosekutilities2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace stikosekutilities2.UI
{
    public static class GUIRenderer
    {
        private static bool prevVisible;
        private static CursorLockMode prevLockState;

        public static bool Shown
        {
            get
            {
                return shown;
            }
            set
            {
                shown = value;

                if (value)
                {
                    prevLockState = Cursor.lockState;
                    prevVisible = Cursor.visible;

                    Cursor.visible = value;
                }
                else
                {
                    Cursor.visible = prevVisible;
                    Cursor.lockState = prevLockState;
                }
            }
        }

        private static bool shown;

        private static readonly List<WindowManager> Windows = new();

        public static void Update()
        {
            if (Shown)
            {
                if (Cursor.lockState != CursorLockMode.Confined)
                {
                    prevLockState = Cursor.lockState;

                    Cursor.lockState = CursorLockMode.Confined;
                }

                if (!Cursor.visible)
                {
                    prevVisible = Cursor.visible;

                    Cursor.visible = true;
                }
            }
        }

        #region Windows
        public static WindowManager GetWindow(WindowID id)
        {
            return Windows.Where(w => w.WindowId == id).FirstOrDefault();
        }

        public static void AddWindow(WindowID id, string text, Rect position)
        {
            if (Windows.Where(window => window.WindowId == id).Any())
                throw new Exception("Duplicated window");
            Windows.Add(new WindowManager(id, position) { Text = text });
        }

        public static void DrawWindows()
        {
            if (!shown)
                return;
            DrawingUtil.DrawFullScreenColor(new Color(0, 0, 0, 0.7f));

            foreach (var window in Windows)
            {
                window.RenderWindow();
            }
        }

        #endregion
    }
}
