using stikosekutilities2.Utils;
using UnityEngine;

namespace stikosekutilities2.UI
{
    public class LayoutHelpers
    {
        public static string ElementHex = "#23a86d";
        public static Color elec = Color.red;

        private static GUIStyle
            horizontalSlider = null,
            horizontalSliderThumb = null;

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

        public static float Slider(float minValue, float maxValue, float value)
        {
            if (value < minValue)
                value = minValue;

            if (value > maxValue)
                value = maxValue;

            if (horizontalSlider == null || horizontalSliderThumb == null)
            {
                ResetSliderStyle();
            }

            if (horizontalSlider.normal == null || horizontalSliderThumb.normal == null)
            {
                ResetSliderStyle();
            }

            if (horizontalSlider.normal.background == null || horizontalSliderThumb.normal.background == null)
            {
                ResetSliderStyle();
            }

            return GUILayout.HorizontalSlider(value, minValue, maxValue, horizontalSlider, horizontalSliderThumb);
        }

        private static void ResetSliderStyle()
        {
            horizontalSlider = new(GUI.skin.horizontalSlider);
            horizontalSliderThumb = new(GUI.skin.horizontalSliderThumb);

            ColorUtility.TryParseHtmlString(WindowManager.BorderHex, out Color sliderBackgroundColor);
            ColorUtility.TryParseHtmlString(ElementHex, out Color thumbBackgroundColor);

            horizontalSlider.normal.background = DrawingUtil.ColoredTexture(sliderBackgroundColor);

            Texture2D thumbTexture = DrawingUtil.ColoredTexture(thumbBackgroundColor);

            horizontalSliderThumb.normal.background = thumbTexture;
            horizontalSliderThumb.hover.background = thumbTexture;
            horizontalSliderThumb.active.background = thumbTexture;
            horizontalSliderThumb.focused.background = thumbTexture;
        }

        public static void Label(string text)
        {
            GUILayout.Label(text);
        }

    }
}
