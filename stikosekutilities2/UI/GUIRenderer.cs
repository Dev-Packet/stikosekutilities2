using stikosekutilities2.Utils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace stikosekutilities2.UI
{
    public static class GUIRenderer
    {
        private static readonly List<WindowManager> Windows = new();

        public static WindowManager GetWindow(WindowID id)
        {
            return Windows.Where(w => w.WindowId == id).FirstOrDefault();
        }

        public static void AddWindow(WindowID id, Rect position)
        {
            Windows.Add(new WindowManager(id, position));
        }

        public static void DrawWindows()
        {
            DrawingUtil.DrawFullScreenColor(new Color(0, 0, 0, 0.7f));
            
            foreach(var window in Windows)
            {
                window.RenderWindow();
            }
        }

    }
}
