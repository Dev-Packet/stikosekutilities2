using stikosekutilities2.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace stikosekutilities2.UI
{
    public class LayoutHelpers
    {
        public static string ElementHex = "#23a86d";
        public static Color elec = Color.red;

        private static GUIStyle
            horizontalSlider,
            horizontalSliderThumb;

        public static bool Toggle(string text, bool toggled)
        {
            GUIContent content = new("haha stikosekutilities go brrrrrrrrrr");

            Rect buttonRect = GUILayoutUtility.GetRect(content, GUI.skin.button, GUILayout.Height(40));

            if (GUI.Button(buttonRect, content))
            {
                toggled = !toggled;
            }

            ColorUtility.TryParseHtmlString(ElementHex, out elec);

            // Draw Button
            DrawingUtil.DrawColor(elec, buttonRect);
            // Draw Button text
            DrawingUtil.DrawText(text, new Rect(buttonRect.x + 5, buttonRect.y + 5, buttonRect.width - 10, buttonRect.height - 10), 15, Color.white);
            // Draw toggle border
            DrawingUtil.DrawColor(WindowManager.Border, new Rect(buttonRect.width - 30, buttonRect.y + 5, 30, 30));

            if (toggled)
            {
                DrawingUtil.DrawColor(elec, new Rect(buttonRect.width - 25, buttonRect.y + 10, 20, 20));
            }

            return toggled;
        }

        public static bool Button(string text)
        {
            GUIContent content = new("haha stikosekutilities go brrrrrrrrrr");

            Rect buttonRect = GUILayoutUtility.GetRect(content, GUI.skin.button, GUILayout.Height(40));

            bool clicked = GUI.Button(buttonRect, content);

            ColorUtility.TryParseHtmlString(ElementHex, out elec);

            // Draw Button
            DrawingUtil.DrawColor(elec, buttonRect);
            // Draw Button text
            DrawingUtil.DrawText(text, new Rect(buttonRect.x + 5, buttonRect.y + 5, buttonRect.width - 10, buttonRect.height - 10), 15, Color.white);

            return clicked;
        }

        public static bool ItemButton(Sprite sprite, Vector2 scrollPosition)
        {
            Texture2D tex = sprite.texture;
            GUIContent content = new(tex);

            Rect buttonRect = GUILayoutUtility.GetRect(content, GUI.skin.button, GUILayout.MaxHeight(69));

            if(IsVisible(buttonRect, scrollPosition))
            {
                DrawingUtil.DrawColor(elec, buttonRect);

                return GUI.Button(buttonRect, content);
            }
            
            return false;
        }

        private static bool IsVisible(Rect buttonRect, Vector2 scrollPosition)
        {
            WindowManager manager = GUIRenderer.GetWindow(WindowID.Items);
            if(buttonRect.yMax < manager.WindowRect.height + scrollPosition.y &&
                buttonRect.yMin > scrollPosition.y)
            {
                return true;
            }

            return false;
        }

        public static float Slider(float minValue, float maxValue, float value)
        {
            if (value < minValue)
                value = minValue;

            if(value > maxValue)
                value = maxValue;

            if (horizontalSlider == null || horizontalSliderThumb == null)
            {
                horizontalSlider = GUI.skin.horizontalSlider;
                horizontalSliderThumb = GUI.skin.horizontalSliderThumb;

                ColorUtility.TryParseHtmlString(WindowManager.BorderHex, out Color sliderBackgroundColor);
                ColorUtility.TryParseHtmlString(ElementHex, out Color thumbBackgroundColor);

                horizontalSlider.normal.background = DrawingUtil.ColoredTexture(sliderBackgroundColor);

                Texture2D thumbTexture = DrawingUtil.ColoredTexture(thumbBackgroundColor);

                horizontalSliderThumb.normal.background = thumbTexture;
                horizontalSliderThumb.hover.background = thumbTexture;
                horizontalSliderThumb.active.background = thumbTexture;
                horizontalSliderThumb.focused.background = thumbTexture;
            }

            return GUILayout.HorizontalSlider(value, minValue, maxValue, horizontalSlider, horizontalSliderThumb);
        }

        public static void Label(string text)
        {
            GUILayout.Label(text);
        }

    }
}
